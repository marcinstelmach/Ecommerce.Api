using System.Threading.Tasks;
using NLog;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract;

namespace Streetwood.Infrastructure.Services.Implementations
{
    internal class EmailService : IEmailService
    {
        private readonly IEmailTemplatesManager emailTemplatesManager;
        private readonly IEmailManager emailManager;
        private readonly ILogger logger;

        public EmailService(IEmailTemplatesManager emailTemplatesManager, IEmailManager emailManager, ILogger logger)
        {
            this.emailTemplatesManager = emailTemplatesManager;
            this.emailManager = emailManager;
            this.logger = logger;
        }

        public async Task SendNewOrderEmailAsync(Order order)
        {
            logger.Info("Sending Email - New order");
        }

        public async Task SendNewUserEmailAsync(User user)
        {
            logger.Info("Sending Email for new user");
        }

        public async Task SendForgottenPasswordEmailAsync(User user)
        {
            var template = await emailTemplatesManager.PrepareForgottenPasswordEmailAsync(user);
            await emailManager.SendAsync(user.Email, user.FullName, "Streetwood Password Reset", template);
        }
    }
}