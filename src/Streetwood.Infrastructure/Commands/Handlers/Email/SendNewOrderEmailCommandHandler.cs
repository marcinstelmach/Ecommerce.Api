using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Email.Models;
using Streetwood.Infrastructure.Services.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Commands.Models.Email.Handlers
{
    public class SendNewOrderEmailCommandHandler : IRequestHandler<SendNewOrderEmailCommandModel>
    {
        private readonly IEmailService emailService;
        private readonly IOrderQueryService orderQueryService;

        public SendNewOrderEmailCommandHandler(IEmailService emailService, IOrderQueryService orderQueryService)
        {
            this.emailService = emailService;
            this.orderQueryService = orderQueryService;
        }

        public async Task<Unit> Handle(SendNewOrderEmailCommandModel request, CancellationToken cancellationToken)
        {
            var order = await orderQueryService.GetRawAndEnsureExistsAsync(request.OrderId);
            await emailService.SendNewOrderEmailAsync(order);

            return Unit.Value;
        }
    }
}
