using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface IEmailTemplatesManager
    {
        Task<string> ReadTemplateAsync(string templateName);
    }
}
