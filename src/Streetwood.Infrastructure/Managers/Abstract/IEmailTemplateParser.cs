using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface IEmailTemplateParser
    {
        string PrepareNewOrderEmailAsync(OrderDto order, string stringTemplate);

        Task<string> PrepareNewUserEmailAsync(UserDto user);

        Task<string> PrepareForgottenPasswordEmailAsync(User user);
    }
}