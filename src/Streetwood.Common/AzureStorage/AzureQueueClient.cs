using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Queue;

namespace Streetwood.Common.AzureStorage
{
    public class AzureQueueClient : IAzureQueueClient
    {
        private readonly CloudQueue cloudQueue;

        public AzureQueueClient(CloudQueue cloudQueue)
        {
            this.cloudQueue = cloudQueue;
        }

        public async Task AddMessageAsync(CloudQueueMessage message)
        {
            await cloudQueue.AddMessageAsync(message);
        }

        public async Task<CloudQueueMessage> GetMessageAsync()
        {
            return await cloudQueue.GetMessageAsync();
        }

        public async Task<IEnumerable<CloudQueueMessage>> GetAllMessagesAsync()
        {
            return await cloudQueue.GetMessagesAsync(32);
        }

        public async Task DeleteMessageAsync(CloudQueueMessage message)
        {
            await cloudQueue.DeleteMessageAsync(message);
        }
    }
}