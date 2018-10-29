using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models;
using Streetwood.Infrastructure.Commands.Models.Shipment;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Shipment
{
    public class UpdateShipmentCommandHandler : IRequestHandler<UpdateShipmentCommandModel, Unit>
    {
        private readonly IShipmentCommandService service;

        public UpdateShipmentCommandHandler(IShipmentCommandService service)
        {
            this.service = service;
        }

        public async Task<Unit> Handle(UpdateShipmentCommandModel request, CancellationToken cancellationToken)
        {
            await service.UpdateAsync(request.Id, request.Name, request.NameEng, request.Description, request.DescriptionEng, request.IsActive, request.Type);
            return Unit.Value;
        }
    }
}
