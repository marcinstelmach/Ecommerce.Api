using System;
using System.Threading.Tasks;
using Streetwood.Infrastructure.Services.Abstract;

namespace Streetwood.Infrastructure.Services.Implementations
{
    internal class EmailService : IEmailService
    {
        public async Task SendAsync(string receiver, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
