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
        private readonly IEmailOptions emailOptions;

        public MailKitManager(IOptions<EmailOptions> emailOptions)
        {
            this.emailOptions = emailOptions.Value;
        }

        public async Task SendAsync(string receiverAddress, string receiverName, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailOptions.SenderAddress, emailOptions.SenderAddress));
            message.To.Add(new MailboxAddress(receiverAddress, receiverAddress));
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

            await client.ConnectAsync(emailOptions.Server, emailOptions.Port, emailOptions.UseSSl);
            await client.AuthenticateAsync(emailOptions.Username, emailOptions.Password);

            return client;
        }
    }
}
