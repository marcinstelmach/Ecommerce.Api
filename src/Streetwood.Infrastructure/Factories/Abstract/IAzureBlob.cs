using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Streetwood.Infrastructure.Factories.Abstract
{
    public interface IAzureBlob
    {
        Task<IAzureBlob> CreateContainerIfNotExists();

        ICloudBlob GetBlob(string name);
    }
}