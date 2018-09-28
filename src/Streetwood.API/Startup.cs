using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Streetwood.API.Filters;
using Streetwood.API.Middleware;
using Streetwood.Core.Extensions;
using Streetwood.Core.Modules;
using Streetwood.Infrastructure.Modules;
using Swashbuckle.AspNetCore.Swagger;

namespace Streetwood.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
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
            services.AddStreetwoodContext();
            services.AddSwaggerGen(s => { s.SwaggerDoc("v1", new Info { Title = "Streetwood API", Version = "v1" }); });

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterInstance(LogManager.GetCurrentClassLogger()).As<ILogger>();
            builder.RegisterModule<RepositoriesModule>();
            builder.RegisterModule<ManagersModule>();
            builder.RegisterModule<ServicesModule>();
            builder.RegisterModule<MediaTrModule>();

            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IApplicationLifetime applicationLifetime)
        {
            if (HostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Streetwood API"));
            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMvc();

            applicationLifetime.ApplicationStopped.Register(() => Container.Dispose());
        }
    }
}
