using Microsoft.WindowsAzure.Storage.Blob;

namespace Streetwood.Infrastructure.Factories.Abstract
{
    public interface IAzureStorageFactory
    {
        IAzureBlobClient CreateStorageAccount(string connectionString);
    }
}