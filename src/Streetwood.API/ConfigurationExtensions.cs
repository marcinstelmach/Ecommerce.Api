using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Streetwood.Core.Constants;

namespace Streetwood.API
{
    public static class ConfigurationExtensions
    {
        public static IWebHostBuilder AddConfiguredSerilog(this IWebHostBuilder builder)
        {
            return builder
                .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration)
                    .Enrich.FromLogContext()
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                    .WriteTo.File(
                        path: GetLogPath(hostingContext.HostingEnvironment),
                        outputTemplate: ConstantValues.LogTemplate,
                        rollingInterval: RollingInterval.Day,
                        rollOnFileSizeLimit: true));
        }

        private static string GetLogPath(IHostingEnvironment env)
            => env.IsDevelopment() ? ConstantValues.DevelopmentLogPath : ConstantValues.ProductionLogPath;
    }
}
