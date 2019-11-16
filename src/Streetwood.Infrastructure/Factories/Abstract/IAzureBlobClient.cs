namespace Streetwood.Infrastructure.Factories.Abstract
{
    public interface IAzureBlobClient
    {
        IAzureBlobContainer ForBlobClient();
    }
}