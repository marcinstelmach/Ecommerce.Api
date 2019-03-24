using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface IEmailTemplatesManager
    {
        Task PrepareNewOrderEmailAsync(Order order);

        Task PrepareNewUserEmailAsync(User user);

        Task ForgottenPasswordEmailAsync(User user);

        Task<string> ReadTemplateAsync(string templateName);
    }
}
