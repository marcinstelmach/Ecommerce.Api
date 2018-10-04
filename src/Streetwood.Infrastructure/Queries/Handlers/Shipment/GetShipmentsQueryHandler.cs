using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.Shipment;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Shipment
{
    public class GetShipmentsQueryHandler : IRequestHandler<GetShipmentsQueryModel, IList<ShipmentDto>>
    {
        private readonly IShipmentQueryService shipmentQueryService;

        public GetShipmentsQueryHandler(IShipmentQueryService shipmentQueryService)
        {
            this.shipmentQueryService = shipmentQueryService;
        }

        public async Task<IList<ShipmentDto>> Handle(GetShipmentsQueryModel request, CancellationToken cancellationToken)
        {
            return await shipmentQueryService.GetAsync();
        }
    }
}
