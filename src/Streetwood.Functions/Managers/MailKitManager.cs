using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Streetwood.Functions.Settings;

namespace Streetwood.Functions.Managers
{
    public class MailKitManager : IEmailManager
    {
        private readonly FunctionSettings functionSettings;

        public MailKitManager(IOptions<FunctionSettings> functionSettings)
        {
            this.functionSettings = functionSettings.Value;
        }

        public async Task SendAsync(string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(functionSettings.EmailSenderName, functionSettings.EmailSenderAddress));
            message.To.Add(new MailboxAddress(functionSettings.EmailReceiverName, functionSettings.EmailReceiverAddressEmail));
            message.Subject = functionSettings.EmailExceptionSubject;
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

            await client.ConnectAsync(functionSettings.EmailServer, functionSettings.EmailPort, functionSettings.EmailUseSSl);
            await client.AuthenticateAsync(functionSettings.EmailUsername, functionSettings.EmailPassword);

            return client;
        }
    }
}