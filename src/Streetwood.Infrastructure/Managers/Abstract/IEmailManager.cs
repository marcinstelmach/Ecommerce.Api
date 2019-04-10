using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface IEmailManager
    {
        Task SendAsync(string receiverAddress, string receiverName, string subject, string body);
    }
}
