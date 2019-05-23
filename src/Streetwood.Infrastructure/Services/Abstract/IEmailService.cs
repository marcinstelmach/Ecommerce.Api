using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract
{
    public interface IEmailService
    {
        Task SendNewOrderEmailAsync(OrderDto order);

        Task SendNewUserEmailAsync(UserDto user);

        Task SendForgottenPasswordEmailAsync(User user);
    }
}
