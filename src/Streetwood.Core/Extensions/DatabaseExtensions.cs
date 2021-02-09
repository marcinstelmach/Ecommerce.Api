using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Implementation;
using Streetwood.Core.Exceptions;
using Streetwood.Core.Settings;

namespace Streetwood.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static void AddStreetwoodContext(this IServiceCollection services)
        {
            var databaseOptions = services
                .BuildServiceProvider()
                .GetRequiredService<IOptions<DatabaseSettings>>()
                .Value;

            services.AddDbContext<StreetwoodContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(databaseOptions.ConnectionString);
            });
            services.AddScoped<IDbContext>(prov => prov.GetRequiredService<StreetwoodContext>());
        }

        public static void AddStreetwoodContextForTests(this IServiceCollection services, ServiceProvider serviceProvider)
        {
            services.AddDbContext<StreetwoodContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
                options.UseInternalServiceProvider(serviceProvider);
            });
            services.AddScoped<IDbContext>(prov => prov.GetRequiredService<StreetwoodContext>());
        }

        public static async Task<T> FindAndEnsureExistsAsync<T>(this DbSet<T> set, Expression<Func<T, bool>> expression, ErrorCode code)
            where T : Entity
        {
            var result = await set.FirstOrDefaultAsync(expression);
            if (result == null)
            {
                throw new StreetwoodException(code);
            }

            return result;
        }
    }
}
