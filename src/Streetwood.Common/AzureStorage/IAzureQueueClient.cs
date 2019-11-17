using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Queue;

namespace Streetwood.Common.AzureStorage
{
    public interface IAzureQueueClient
    {
        Task AddMessageAsync(CloudQueueMessage message);

        Task<CloudQueueMessage> GetMessageAsync();

        Task<IEnumerable<CloudQueueMessage>> GetAllMessagesAsync();

        Task DeleteMessageAsync(CloudQueueMessage message);
    }
}