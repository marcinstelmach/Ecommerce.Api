using Microsoft.Extensions.Configuration;
using Streetwood.Core.Settings;

namespace Streetwood.Test.Helpers
{
    public class EmailHelper
    {
        public static IConfiguration Configuration { get; } = TestSettingsManager.GetConfiguration();
        public static EmailOptions GetTestEmailOptions()
        {
            var options = new EmailOptions();
            Configuration.GetSection("Email").Bind(options);

            return options;
        }

        public static string GetReceiverAddress()
        {
            return Configuration["EmailReceiver:address"];
        }
    }
}
