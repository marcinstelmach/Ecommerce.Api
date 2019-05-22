using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Infrastructure.Services.Abstract
{
    public interface IEmailService
    {
        Task SendNewOrderEmailAsync(Order order);

        Task SendNewUserEmailAsync(User user);

        Task SendForgottenPasswordEmailAsync(User user);
    }
}
