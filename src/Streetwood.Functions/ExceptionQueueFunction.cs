using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Streetwood.Functions.Managers;

namespace Streetwood.Functions
{
    public class ExceptionQueueFunction
    {
        private const string QueueName = "exceptions-queue";
        private const string ConnectionName = "AzureWebJobsStorage";

        private readonly IEmailManager emailManager;

        public ExceptionQueueFunction(IEmailManager emailManager)
        {
            this.emailManager = emailManager;
        }

        [FunctionName("ExceptionQueueFunction")]
        public async Task Run([QueueTrigger(QueueName, Connection = ConnectionName)]string message, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {message}");
            await emailManager.SendAsync(message);
        }
    }
}
