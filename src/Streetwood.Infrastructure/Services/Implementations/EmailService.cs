using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Settings;
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
        private readonly EmailTemplatesOptions emailTemplatesOptions;

        public EmailService(
            IEmailTemplatesManager emailTemplatesManager,
            IEmailManager emailManager, IEmailTemplateParser emailTemplateParser,
            IOptions<EmailTemplatesOptions> emailTemplatesOptions)
        {
            this.emailTemplatesManager = emailTemplatesManager;
            this.emailManager = emailManager;
            this.emailTemplateParser = emailTemplateParser;
            this.emailTemplatesOptions = emailTemplatesOptions.Value;
        }

        public async Task SendNewOrderEmailAsync(OrderDto order)
        {
            var template = await emailTemplatesManager.ReadTemplateAsync(emailTemplatesOptions.NewOrder.TemplateName);
            template = emailTemplateParser.PrepareNewOrderEmailAsync(order, template);
            var subject = ParseNewOrderSubject(emailTemplatesOptions.NewOrder.Subject, order.Id);
            await emailManager.SendAsync(order.User.Email, order.User.FullName, subject, template);
        }

        public async Task SendNewUserEmailAsync(User user)
        {
            var template = await emailTemplatesManager.ReadTemplateAsync(emailTemplatesOptions.ActivateNewUser.TemplateName);
            template = emailTemplateParser.PrepareActivateNewUserEmail(user, template);
            await emailManager.SendAsync(user.Email, user.FullName, emailTemplatesOptions.ActivateNewUser.Subject, template);
        }

        public async Task SendResetPasswordEmailAsync(User user)
        {
            var template = await emailTemplatesManager.ReadTemplateAsync(emailTemplatesOptions.ResetPassword.TemplateName);
            template = emailTemplateParser.PrepareResetPasswordEmail(user, template);
            await emailManager.SendAsync(user.Email, user.FullName, emailTemplatesOptions.ResetPassword.Subject, template);
        }

        private static string ParseNewOrderSubject(string subject, int orderId)
        {
            return subject.Replace("{{{orderId}}}", orderId.ToString(CultureInfo.InvariantCulture));
        }
    }
}