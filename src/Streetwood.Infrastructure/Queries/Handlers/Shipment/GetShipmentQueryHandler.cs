using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.Shipment;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Shipment
{
    public class GetShipmentQueryHandler : IRequestHandler<GetShipmentQueryModel, ShipmentDto>
    {
        private readonly IShipmentQueryService service;

        public GetShipmentQueryHandler(IShipmentQueryService service)
        {
            this.service = service;
        }

        public async Task<ShipmentDto> Handle(GetShipmentQueryModel request, CancellationToken cancellationToken)
            => await service.GetAsync(request.Id);
    }
}
