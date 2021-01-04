using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Streetwood.Functions.Managers;

namespace Streetwood.Functions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddOptions<Settings.FunctionSettings>()
                .Configure<IConfiguration>((settings, configuration) => { configuration.Bind(settings); });

            services.AddTransient<IEmailManager, MailKitManager>();
            services.AddHttpClient<AlwaysOnFunction>();
        }
    }
}