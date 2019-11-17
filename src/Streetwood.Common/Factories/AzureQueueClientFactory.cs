using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Streetwood.Common.AzureStorage;

namespace Streetwood.Common.Factories
{
    public class AzureQueueClientFactory : IAzureQueueClientFactory
    {
        public IAzureQueueClient CreateQueueClient(string connectionString, string queueName)
        {
            var storageAccount = CloudStorageAccount.Parse(queueName);
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName);

            return new AzureQueueClient(queue);
        }
    }
}