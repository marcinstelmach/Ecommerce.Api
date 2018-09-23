using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Streetwood.Core.Settings;

namespace Streetwood.Core.Extensions
{
    public static class SettingsExtensions
    {
        public static void AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseOptions>(configuration.GetSection("Database"));
        }
    }
}
