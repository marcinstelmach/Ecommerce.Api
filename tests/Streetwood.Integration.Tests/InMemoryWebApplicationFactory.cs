using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Integration.Tests.DbInitializations;
using Streetwood.Test.Helpers.Mocks;

namespace Streetwood.Integration.Tests
{
    public class InMemoryWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddStreetwoodContextForTests(serviceProvider);

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var dbContext = scopedServices.GetRequiredService<IDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<InMemoryWebApplicationFactory<TStartup>>>();

                    dbContext.EnsureDatabaseCreated();

                    try
                    {
                        DbInitialization.InitDb(dbContext);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}