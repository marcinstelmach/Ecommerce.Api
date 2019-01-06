using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Streetwood.Core.Settings;

namespace Streetwood.Core.Extensions
{
    public static class SettingsExtensions
    {
        public static void AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseOptions>(configuration.GetSection("Database"));
            services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
            services.Configure<CacheOptions>(configuration.GetSection("Cache"));
        }
    }
}
