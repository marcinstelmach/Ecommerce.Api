using System;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract;

namespace Streetwood.Infrastructure.Services.Implementations
{
    internal class EmailService : IEmailService
    {
        private readonly IEmailTemplatesManager emailTemplatesManager;
        private readonly IEmailManager emailManager;

        public EmailService(IEmailTemplatesManager emailTemplatesManager, IEmailManager emailManager)
        {
            this.emailTemplatesManager = emailTemplatesManager;
            this.emailManager = emailManager;
        }

        public async Task SendPrepareNewOrderEmailAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task SendNewUserEmailAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task SendForgottenPasswordEmailAsync(User user)
        {
            var template = await emailTemplatesManager.PrepareForgottenPasswordEmailAsync(user);
            await emailManager.SendAsync(user.Email, user.FullName, "Streetwood Password Reset", template);
        }
    }
}