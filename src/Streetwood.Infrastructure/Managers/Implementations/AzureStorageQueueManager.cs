using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Streetwood.Core.Exceptions;
using Streetwood.Core.Settings;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    internal class AzureStorageQueueManager : IQueueManager
    {
        private readonly CloudOptions cloudOptions;

        public AzureStorageQueueManager(IOptions<CloudOptions> cloudOptions)
        {
            this.cloudOptions = cloudOptions.Value;
        }

        public async Task AddMessageAsync(string message)
        {
            var storageAccount = CloudStorageAccount.Parse(cloudOptions.StorageConnectionString);
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(cloudOptions.ExceptionQueue);
            var queueMessage = new CloudQueueMessage(message);

            try
            {
                await queue.AddMessageAsync(queueMessage);
            }
            catch (Exception exception)
            {
                throw new StreetwoodException(ErrorCode.CannotAddToQueue,
                    "Error while adding exception message to queue.", exception);
            }
        }
    }
}