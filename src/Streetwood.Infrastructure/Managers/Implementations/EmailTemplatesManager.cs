using System;
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

        public EmailTemplatesManager(IPathManager pathManager)
        {
            this.pathManager = pathManager;
        }

        public async Task<string> ReadTemplateAsync(string templateName)
        {
            var templatePath = pathManager.GetEmailTemplatePath(templateName);
            if (!File.Exists(templatePath))
            {
                throw new StreetwoodException(ErrorCode.EmailTemplateNotExists(templateName));
            }

            var emailTemplate = await File.ReadAllTextAsync(templatePath);
            if (string.IsNullOrEmpty(emailTemplate))
            {
                throw new Exception($"Cannot read email template from path: '{templateName}'.");
            }

            return emailTemplate;
        }
    }
}
