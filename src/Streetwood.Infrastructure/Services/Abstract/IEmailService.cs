using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract
{
    public interface IEmailService
    {
        Task SendNewOrderEmailAsync(Order order);

        Task SendNewUserEmailAsync(User user);

        Task SendResetPasswordEmailAsync(User user);

        Task SendOrderWasShippedEmailAsync(Order order);
    }
}
