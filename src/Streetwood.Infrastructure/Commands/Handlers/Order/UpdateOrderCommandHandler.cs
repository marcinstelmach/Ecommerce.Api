using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Order;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Order
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandModel>
    {
        private readonly IOrderCommandService orderCommandService;

        public UpdateOrderCommandHandler(IOrderCommandService orderCommandService)
        {
            this.orderCommandService = orderCommandService;
        }

        public async Task<Unit> Handle(UpdateOrderCommandModel request, CancellationToken cancellationToken)
        {
            await orderCommandService.UpdateAsync(request.Id, request.PayedDateTime, request.ShipmentDateTime,
                request.ClosedDateTime);

            return Unit.Value;
        }
    }
}
