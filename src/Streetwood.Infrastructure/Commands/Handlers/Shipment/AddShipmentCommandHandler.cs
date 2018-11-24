using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Shipment;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Shipment
{
    public class AddShipmentCommandHandler : IRequestHandler<AddShipmentCommandModel, Unit>
    {
        private readonly IShipmentCommandService shipmentCommandService;

        public AddShipmentCommandHandler(IShipmentCommandService shipmentCommandService)
        {
            this.shipmentCommandService = shipmentCommandService;
        }

        public async Task<Unit> Handle(AddShipmentCommandModel request, CancellationToken cancellationToken)
        {
            await shipmentCommandService.AddAsync(request.Name, request.NameEng, request.Description,
                request.DescriptionEng, request.Price, request.Type);
            return Unit.Value;
        }
    }
}
