using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Streetwood.Core.Settings;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    internal class MailKitManager : IEmailManager
    {
        private readonly EmailSettings emailSettings;

        public MailKitManager(IOptions<EmailSettings> emailSettings)
        {
            this.emailSettings = emailSettings.Value;
        }

        public async Task SendAsync(string receiverAddress, string receiverName, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailSettings.SenderName, emailSettings.SenderAddress));
            message.To.Add(new MailboxAddress(receiverName, receiverAddress));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = body
            };

            var smtpClient = await GetClient();
            await smtpClient.SendAsync(message);
            await smtpClient.DisconnectAsync(true);
            smtpClient.Dispose();
        }

        private async Task<SmtpClient> GetClient()
        {
            var client = new SmtpClient { ServerCertificateValidationCallback = (s, c, h, e) => true };

            await client.ConnectAsync(emailSettings.Server, emailSettings.Port, emailSettings.UseSSl);
            await client.AuthenticateAsync(emailSettings.Username, emailSettings.Password);

            return client;
        }
    }
}
