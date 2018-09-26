using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Implementation;
using Streetwood.Core.Settings;

namespace Streetwood.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static void AddStreetwoodContext(this IServiceCollection services)
        {
            var databaseOptions = services
                .BuildServiceProvider()
                .GetRequiredService<IOptions<DatabaseOptions>>()
                .Value;

            services.AddDbContext<StreetwoodContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(databaseOptions.ConnectionString);
            });
            services.AddScoped<IDbContext>(prov => prov.GetRequiredService<StreetwoodContext>());
        }
    }
}
