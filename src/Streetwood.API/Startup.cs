using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using Streetwood.API.Bus;
using Streetwood.API.Filters;
using Streetwood.API.Middleware;
using Streetwood.Core.Extensions;
using Streetwood.Core.Modules;
using Streetwood.Infrastructure.Modules;
using Swashbuckle.AspNetCore.Swagger;
using ILogger = NLog.ILogger;

namespace Streetwood.API
{
    public class Startup
    {
        private readonly ILogger logger;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
            logger = LogManager.GetCurrentClassLogger();
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment HostingEnvironment { get; }

        public IContainer Container { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(opt => opt.Filters.Add(typeof(ValidationActionFilter)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<ApiBehaviorOptions>(opt => opt.SuppressModelStateInvalidFilter = true);
            services.AddApplicationSettings(Configuration);
            services.AddJwtAuth();
            services.AddStreetwoodContext();
            services.AddSwaggerGen(s => { s.SwaggerDoc("v1", new Info { Title = "Streetwood API", Version = "v1" }); });
            services.AddMemoryCache();
            services.AddScoped<IBus, Bus.MediatorBus>();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterInstance(logger).As<ILogger>();
            builder.RegisterModule<RepositoriesModule>();
            builder.RegisterModule<ManagersModule>();
            builder.RegisterModule<MediaTrModule>();
            builder.RegisterModule<MapperModule>();
            builder.RegisterModule<ServicesModule>();

            Container = builder.Build();
            var serviceProvider = new AutofacServiceProvider(Container);

            return serviceProvider;
        }

        public void Configure(IApplicationBuilder app, IApplicationLifetime applicationLifetime, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            HostingEnvironment.ConfigureNLog($"nlog.{HostingEnvironment.EnvironmentName}.config");

            if (HostingEnvironment.IsDevelopment() || HostingEnvironment.IsStaging())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Streetwood API"));
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseCors(s =>
            {
                s.AllowAnyOrigin();
                s.AllowAnyHeader();
                s.AllowAnyMethod();
            });

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMvc();

            applicationLifetime.ApplicationStopped.Register(() => Container.Dispose());
            logger.Info("Application successfully configured.");
        }
    }
}
