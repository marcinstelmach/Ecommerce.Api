using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Streetwood.Common.Factories;
using Streetwood.Functions;
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
            builder.Services.AddScoped<IAzureQueueClientFactory, AzureQueueClientFactory>();
        }
    }
}
