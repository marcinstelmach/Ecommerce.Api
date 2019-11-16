namespace Streetwood.Infrastructure.Factories.Abstract
{
    public interface IAzureBlobContainer
    {
        IAzureBlob WithContainer(string containerName);
    }
}