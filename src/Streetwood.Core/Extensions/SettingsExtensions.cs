using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Streetwood.Core.Settings;

namespace Streetwood.Core.Extensions
{
    public static class SettingsExtensions
    {
        private const string DatabaseSettingsKey = "DatabaseSettings";
        private const string JwtSettingsKey = "JwtSettings";
        private const string CacheSettingsKey = "CacheSettings";
        private const string EmailSettingsKey = "EmailSettings";
        private const string ExceptionToolSettingsKey = "ExceptionToolSettings";
        private const string EmailTemplateSettingsKey = "EmailTemplateSettings";
        private const string ClientSettingsKey = "ClientSettings";

        public static void AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection(DatabaseSettingsKey));
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettingsKey));
            services.Configure<CacheSettings>(configuration.GetSection(CacheSettingsKey));
            services.Configure<EmailSettings>(configuration.GetSection(EmailSettingsKey));
            services.Configure<ExceptionToolSettings>(configuration.GetSection(ExceptionToolSettingsKey));
            services.Configure<EmailTemplateSettings>(configuration.GetSection(EmailTemplateSettingsKey));
            services.Configure<ClientSettings>(configuration.GetSection(ClientSettingsKey));
        }
    }
}