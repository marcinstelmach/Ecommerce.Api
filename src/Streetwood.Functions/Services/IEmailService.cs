using System.Threading.Tasks;

namespace Streetwood.Functions.Services
{
    public interface IEmailService
    {
        Task SendExceptionEmailAsync(string message);
    }
}