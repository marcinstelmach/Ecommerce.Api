using System.Threading.Tasks;

namespace Streetwood.Functions.Managers
{
    public interface IEmailManager
    {
        Task SendAsync(string body);
    }
}