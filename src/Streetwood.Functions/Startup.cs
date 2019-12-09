using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Streetwood.Functions;
using Streetwood.Functions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Streetwood.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.RegisterServices();
        }
    }
}
