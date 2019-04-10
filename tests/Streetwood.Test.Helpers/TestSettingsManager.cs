using Microsoft.Extensions.Configuration;

namespace Streetwood.Test.Helpers
{
    public class TestSettingsManager
    {
        public static IConfiguration GetConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.Test.json")
                .Build();

            return config;
        }
    }
}
