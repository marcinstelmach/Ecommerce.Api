using System.Linq;
using System.Threading.Tasks;
using Streetwood.Functions.Services;

namespace Streetwood.Functions.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly IQueueService queueService;

        public ExceptionHandler(IQueueService queueService)
        {
            this.queueService = queueService;
        }

        public async Task HandleAsync()
        {
            var messages = await queueService.GetMessagesAsync();
            if (messages.Any())
            {
                
            }
        }
    }
}