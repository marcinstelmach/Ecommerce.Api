using System.Threading.Tasks;

namespace Streetwood.Common.Email
{
    public interface IEmailManager
    {
        Task SendAsync(string receiverAddress, string receiverName, string subject, string body);
    }
}
