using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface IEmailTemplatesManager
    {
        Task<string> ReadTemplateAsync(string templateName);

        Task<string> PrepareNewOrderEmailAsync(Order order);

        Task<string> PrepareNewUserEmailAsync(User user);

        Task<string> PrepareForgottenPasswordEmailAsync(User user);
    }
}
