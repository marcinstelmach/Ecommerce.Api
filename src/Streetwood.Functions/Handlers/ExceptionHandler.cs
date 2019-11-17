using System.Threading.Tasks;

namespace Streetwood.Functions.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async Task HandleAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}