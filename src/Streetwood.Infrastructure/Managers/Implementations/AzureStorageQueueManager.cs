using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Streetwood.Core.Settings;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    internal class AzureStorageQueueManager : IQueueManager
    {
        private readonly ExceptionToolSettings exceptionsToolSettings;

        public AzureStorageQueueManager(IOptions<ExceptionToolSettings> cloudOptions)
        {
            this.exceptionsToolSettings = cloudOptions.Value;
        }

        public async Task AddMessageAsync(string message)
        {
            var storageAccount = CloudStorageAccount.Parse(exceptionsToolSettings.StorageConnectionString);
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(exceptionsToolSettings.ExceptionQueueName);
            var queueMessage = new CloudQueueMessage(message);

            await queue.AddMessageAsync(queueMessage);
        }
    }
}