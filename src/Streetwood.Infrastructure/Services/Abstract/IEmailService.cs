using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Services.Abstract
{
    public interface IEmailService
    {
        Task SendAsync(string receiver, string subject, string body);
    }
}
