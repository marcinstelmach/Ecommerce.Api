using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface IEmailTemplateParser
    {
        string PrepareNewOrderEmailAsync(OrderDto order, string stringTemplate);

        string PrepareActivateNewUserEmail(User user, string stringTemplate);

        string PrepareResetPasswordEmail(User user, string stringTemplate);
    }
}