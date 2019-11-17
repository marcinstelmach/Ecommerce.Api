using System.Threading.Tasks;

namespace Streetwood.Functions.Handlers
{
    public interface IExceptionHandler
    {
        Task HandleAsync();
    }
}