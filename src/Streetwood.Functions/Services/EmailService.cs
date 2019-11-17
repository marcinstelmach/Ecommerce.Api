using System.Threading.Tasks;
using Streetwood.Common.Email;

namespace Streetwood.Functions.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailManager emailManager;

        public EmailService(IEmailManager emailManager)
        {
            this.emailManager = emailManager;
        }

        public async Task SendExceptionEmailAsync(string message)
        {
            await emailManager.SendAsync()
        }
    }
}