using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Streetwood.Common.Email;
using Streetwood.Common.Factories;
using Streetwood.Functions;
using Streetwood.Functions.Handlers;
using Streetwood.Functions.Settings;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Streetwood.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<QueueSettings>()
                .Configure<IConfiguration>((settings, configuration) => { configuration.Bind(settings); });
            builder.Services.AddOptions<ExceptionEmailSettings>()
                .Configure<IConfiguration>((settings, configuration) => { configuration.Bind(settings); });
            builder.Services.AddScoped<IAzureQueueClientFactory, AzureQueueClientFactory>();
            builder.Services.AddTransient<IEmailManager, MailKitManager>();
            builder.Services.AddTransient<IExceptionHandler, ExceptionHandler>();
        }
    }
}
