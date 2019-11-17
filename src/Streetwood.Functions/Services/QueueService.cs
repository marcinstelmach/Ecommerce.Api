using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Extensions.Options;
using Streetwood.Common.Factories;
using Streetwood.Functions.Settings;

namespace Streetwood.Functions.Services
{
    public class QueueService : IQueueService
    {
        private readonly IAzureQueueClientFactory azureQueueClientFactory;
        private readonly QueueSettings queueSettings;

        public QueueService(IAzureQueueClientFactory azureQueueClientFactory, IOptions<QueueSettings> queueSettings)
        {
            this.azureQueueClientFactory = azureQueueClientFactory;
            this.queueSettings = queueSettings.Value;
        }

        public async Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync()
        {
            var client = azureQueueClientFactory.CreateQueueClient(queueSettings.ConnectionString, queueSettings.QueueName);
            var messages = await client.GetAllMessagesAsync();

            return messages;
        }

        public async Task RemoveMessage(CloudQueueMessage queueMessage)
        {
            var client = azureQueueClientFactory.CreateQueueClient(queueSettings.ConnectionString, queueSettings.QueueName);
            await client.DeleteMessageAsync(queueMessage);
        }
    }
}