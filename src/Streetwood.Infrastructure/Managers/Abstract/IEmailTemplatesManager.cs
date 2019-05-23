using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface IEmailTemplatesManager
    {
        Task<string> ReadTemplateAsync(string templateName);

        Task<string> PrepareNewOrderEmailAsync(OrderDto order);

        Task<string> PrepareNewUserEmailAsync(UserDto user);

        Task<string> PrepareForgottenPasswordEmailAsync(User user);
    }
}
