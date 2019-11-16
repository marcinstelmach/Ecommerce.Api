using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Streetwood.Infrastructure.Factories.Abstract;

namespace Streetwood.Infrastructure.Factories.Implementation
{
    public class AzureBlobStorageFactory : IAzureStorageFactory, IAzureBlobClient, IAzureBlobContainer, IAzureBlob
    {
        private CloudStorageAccount storageAccount;
        private CloudBlobClient cloudBlobClient;
        private CloudBlobContainer cloudBlobContainer;

        public IAzureBlobClient CreateStorageAccount(string connectionString)
        {
            storageAccount = CloudStorageAccount.Parse(connectionString);
            return this;
        }

        public IAzureBlobContainer ForBlobClient()
        {
            cloudBlobClient = storageAccount.CreateCloudBlobClient();
            return this;
        }

        public IAzureBlob WithContainer(string containerName)
        {
            cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
            return this;
        }

        public ICloudBlob GetBlob(string name)
        {
            return cloudBlobContainer.GetBlockBlobReference(name);
        }

        public async Task<IAzureBlob> CreateContainerIfNotExists()
        {
            await cloudBlobContainer.CreateIfNotExistsAsync();
            return this;
        }
    }
}