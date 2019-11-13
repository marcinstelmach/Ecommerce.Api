using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Streetwood.Core.Exceptions;
using Streetwood.Core.Settings;
using Streetwood.Infrastructure.Factories.Abstract;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    internal class EmailTemplatesManager : IEmailTemplatesManager
    {
        private readonly IPathManager pathManager;
        private readonly IAzureStorageFactory azureStorageFactory;
        private readonly CloudOptions cloudOptions;

        public EmailTemplatesManager(IPathManager pathManager, IAzureStorageFactory azureStorageFactory, IOptions<CloudOptions> cloudOptions)
        {
            this.pathManager = pathManager;
            this.azureStorageFactory = azureStorageFactory;
            this.cloudOptions = cloudOptions.Value;
        }

        public async Task<string> ReadTemplateAsync(string templateName)
        {
            var templatePath = pathManager.GetEmailTemplatePath(templateName);
            if (!File.Exists(templatePath))
            {
                throw new StreetwoodException(ErrorCode.EmailTemplateNotExists(templateName));
            }

            var emailTemplate = await File.ReadAllTextAsync(templatePath);

            var blob = azureStorageFactory
                .CreateStorageAccount(cloudOptions.StorageConnectionString)
                .ForBlobClient()
                .WithContainer(cloudOptions.EmailTemplatesContainerName)
                .GetBlob(templateName);

            using var stream = new MemoryStream();
            await blob.DownloadToStreamAsync(stream);
            using var streamReader = new StreamReader(stream);
            return await streamReader.ReadToEndAsync();
        }
    }
}
