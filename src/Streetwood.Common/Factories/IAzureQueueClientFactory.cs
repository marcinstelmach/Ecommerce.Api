using Streetwood.Common.AzureStorage;

namespace Streetwood.Common.Factories
{
    public interface IAzureQueueClientFactory
    {
        IAzureQueueClient CreateQueueClient(string connectionString, string queueName);
    }
}