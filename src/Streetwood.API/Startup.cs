using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Streetwood.API.Bus;
using Streetwood.API.Filters;
using Streetwood.API.Middleware;
using Streetwood.Core.Extensions;
using Streetwood.Core.Modules;
using Streetwood.Infrastructure.Modules;
using Swashbuckle.AspNetCore.Swagger;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Streetwood.API
{
    public class Startup
    {
        private readonly ILogger logger;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment, ILogger<Startup> logger)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment HostingEnvironment { get; }

        public IContainer Container { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            logger.LogInformation("Application (re)started.");
            services.AddMvc(opt => opt.Filters.Add(typeof(ValidationActionFilter)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<ApiBehaviorOptions>(opt => opt.SuppressModelStateInvalidFilter = true);
            services.AddApplicationSettings(Configuration);
            services.AddJwtAuth();
            services.AddStreetwoodContext();
            services.AddSwaggerGen(s => { s.SwaggerDoc("v1", new Info { Title = "Streetwood API", Version = "v1" }); });
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddScoped<IBus, MediatorBus>();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<RepositoriesModule>();
            builder.RegisterModule<ManagersModule>();
            builder.RegisterModule<MediaTrModule>();
            builder.RegisterModule<MapperModule>();
            builder.RegisterModule<ServicesModule>();
            builder.RegisterModule<HelpersModule>();

            Container = builder.Build();
            var serviceProvider = new AutofacServiceProvider(Container);

            return serviceProvider;
        }

        public void Configure(IApplicationBuilder app, IApplicationLifetime applicationLifetime, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

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
            logger.LogInformation("Application successfully configured.");
        }
    }
}
