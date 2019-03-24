using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface IEmailManager
    {
        Task SendAsync(string receiver, string subject, string body);

        Task PrepareNewOrderEmailAsync(Order order);

        Task PrepareNewUserEmailAsync(User user);

        Task ForgottenPasswordEmailAsync(User user);
    }
}
