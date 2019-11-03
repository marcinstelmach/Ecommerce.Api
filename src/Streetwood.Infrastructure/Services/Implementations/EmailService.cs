using System.Threading.Tasks;
using Streetwood.Core.Constants;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract;

namespace Streetwood.Infrastructure.Services.Implementations
{
    internal class EmailService : IEmailService
    {
        private readonly IEmailTemplateParser emailTemplateParser;
        private readonly IEmailTemplatesManager emailTemplatesManager;
        private readonly IEmailManager emailManager;

        public EmailService(IEmailTemplatesManager emailTemplatesManager, IEmailManager emailManager, IEmailTemplateParser emailTemplateParser)
        {
            this.emailTemplatesManager = emailTemplatesManager;
            this.emailManager = emailManager;
            this.emailTemplateParser = emailTemplateParser;
        }

        public async Task SendNewOrderEmailAsync(OrderDto order)
        {
            var template = await emailTemplatesManager.ReadTemplateAsync(ConstantValues.NewEmailOrderTemplate);
            template = emailTemplateParser.PrepareNewOrderEmailAsync(order, template);
            await emailManager.SendAsync(order.User.Email, order.User.FullName, $"New order no.{order.Id}", template);
        }

        public async Task SendNewUserEmailAsync(UserDto user)
        {
            var template = await emailTemplateParser.PrepareNewUserEmailAsync(user);
            await emailManager.SendAsync(user.FirstName, user.FullName, "Welcome in streetwood !", template);
        }

        public async Task SendForgottenPasswordEmailAsync(User user)
        {
            var template = await emailTemplateParser.PrepareForgottenPasswordEmailAsync(user);
            await emailManager.SendAsync(user.Email, user.FullName, "Streetwood Password Reset", template);
        }
    }
}