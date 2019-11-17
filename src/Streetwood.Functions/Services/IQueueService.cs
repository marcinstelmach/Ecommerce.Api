using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Queue;

namespace Streetwood.Functions.Services
{
    public interface IQueueService
    {
        Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync();

        Task RemoveMessage(CloudQueueMessage queueMessage);
    }
}