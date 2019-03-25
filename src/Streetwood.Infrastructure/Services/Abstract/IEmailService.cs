using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Infrastructure.Services.Abstract
{
    public interface IEmailService
    {
        Task SendAsync(string receiver, string subject, string body);

        Task<string> PrepareNewOrderEmailAsync(Order order);

        Task<string> PrepareNewUserEmailAsync(User user);

        Task<string> ForgottenPasswordEmailAsync(User user);
    }
}
