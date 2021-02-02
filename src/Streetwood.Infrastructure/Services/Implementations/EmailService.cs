using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Settings;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract;

namespace Streetwood.Infrastructure.Services.Implementations
{
    internal class EmailService : IEmailService
    {
        private readonly IEmailTemplateParser emailTemplateParser;
        private readonly IEmailTemplatesManager emailTemplatesManager;
        private readonly IEmailManager emailManager;
        private readonly EmailTemplateSettings emailTemplateSettings;

        public EmailService(
            IEmailTemplatesManager emailTemplatesManager,
            IEmailManager emailManager, IEmailTemplateParser emailTemplateParser,
            IOptions<EmailTemplateSettings> emailTemplatesOptions)
        {
            this.emailTemplatesManager = emailTemplatesManager;
            this.emailManager = emailManager;
            this.emailTemplateParser = emailTemplateParser;
            this.emailTemplateSettings = emailTemplatesOptions.Value;
        }

        public async Task SendNewOrderEmailAsync(Order order)
        {
            var template = await emailTemplatesManager.ReadTemplateAsync(emailTemplateSettings.NewOrder.TemplateName);
            template = emailTemplateParser.PrepareNewOrderEmailAsync(order, template);
            var subject = ParseSubjectOrderId(emailTemplateSettings.NewOrder.Subject, order.Id);
            await emailManager.SendAsync(order.User.Email, order.User.FullName, subject, template);
        }

        public async Task SendNewUserEmailAsync(User user)
        {
            var template = await emailTemplatesManager.ReadTemplateAsync(emailTemplateSettings.ActivateNewUser.TemplateName);
            template = emailTemplateParser.PrepareActivateNewUserEmail(user, template);
            await emailManager.SendAsync(user.Email, user.FullName, emailTemplateSettings.ActivateNewUser.Subject, template);
        }

        public async Task SendResetPasswordEmailAsync(User user)
        {
            var template = await emailTemplatesManager.ReadTemplateAsync(emailTemplateSettings.ResetPassword.TemplateName);
            template = emailTemplateParser.PrepareResetPasswordEmail(user, template);
            await emailManager.SendAsync(user.Email, user.FullName, emailTemplateSettings.ResetPassword.Subject, template);
        }

        public async Task SendOrderWasShippedEmailAsync(Order order)
        {
            var template = await emailTemplatesManager.ReadTemplateAsync(emailTemplateSettings.OrderWasShipped.TemplateName);
            template = emailTemplateParser.PrepareOrderWasShippedEmail(order, template);
            var subject = ParseSubjectOrderId(emailTemplateSettings.OrderWasShipped.Subject, order.Id);
            await emailManager.SendAsync(order.User.Email, order.User.FullName, subject, template);
        }

        private static string ParseSubjectOrderId(string subject, int orderId)
        {
            return subject.Replace("{{{OrderId}}}", orderId.ToString(CultureInfo.InvariantCulture));
        }
    }
}