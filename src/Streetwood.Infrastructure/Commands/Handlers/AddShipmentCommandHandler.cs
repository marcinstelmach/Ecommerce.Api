using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers
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
                request.DescriptionEng, request.Price, request.IsActive, request.Type);
            return Unit.Value;
        }
    }
}
