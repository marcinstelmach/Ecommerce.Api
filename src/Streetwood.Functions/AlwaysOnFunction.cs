using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Streetwood.Functions.Settings;

namespace Streetwood.Functions
{
    public class AlwaysOnFunction
    {
        private readonly HttpClient httpClient;
        private readonly FunctionSettings functionSettings;

        public AlwaysOnFunction(HttpClient httpClient, IOptions<FunctionSettings> functionSettings)
        {
            this.httpClient = httpClient;
            this.functionSettings = functionSettings.Value;
        }

        [FunctionName("AlwaysOnFunction")]
        public async Task RunAsync([TimerTrigger("0 */7 * * * *")]TimerInfo myTimer, ILogger log)
        {
            var response = await httpClient.GetAsync(functionSettings.GetProductsUrlApi);
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                log.LogError($"AlwaysOn failed with: {content}");
            }
        }
    }
}
