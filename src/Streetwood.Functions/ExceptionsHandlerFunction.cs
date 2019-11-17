using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Streetwood.Functions.Options;

namespace Streetwood.Functions
{
    public class ExceptionsHandlerFunction
    {
        private readonly QueueSettings queueSettings;

        public ExceptionsHandlerFunction(IOptions<QueueSettings> queueSettings)
        {
            this.queueSettings = queueSettings.Value;
        }

        [FunctionName("ExceptionsHandlerFunction")]
        public async Task Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"{queueSettings.QueueName}");
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
