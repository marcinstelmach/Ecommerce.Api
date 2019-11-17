using Microsoft.Extensions.Configuration;
using Streetwood.Core.Settings;

namespace Streetwood.Test.Helpers
{
    public class EmailHelper
    {
        public static IConfiguration Configuration { get; } = TestSettingsManager.GetConfiguration();
        public static EmailSettings GetTestEmailOptions()
        {
            var options = new EmailSettings();
            Configuration.GetSection("Email").Bind(options);

            return options;
        }

        public static string GetReceiverAddress()
        {
            return Configuration["EmailReceiver:address"];
        }
    }
}
