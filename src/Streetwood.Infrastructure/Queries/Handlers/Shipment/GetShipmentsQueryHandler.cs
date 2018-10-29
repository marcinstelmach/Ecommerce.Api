using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.Shipment;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Shipment
{
    public class GetShipmentsQueryHandler : IRequestHandler<GetShipmentsQueryModel, IList<ShipmentDto>>
    {
        private readonly IShipmentQueryService shipmentQueryService;
        private readonly IMemoryCache cache;

        public GetShipmentsQueryHandler(IShipmentQueryService shipmentQueryService, IMemoryCache cache)
        {
            this.shipmentQueryService = shipmentQueryService;
            this.cache = cache;
        }

        public async Task<IList<ShipmentDto>> Handle(GetShipmentsQueryModel request, CancellationToken cancellationToken)
        {
            var result = await cache.GetOrAddAsync(CacheKey.Shipments, s => shipmentQueryService.GetAsync());

            return result;
        }
    }
}
