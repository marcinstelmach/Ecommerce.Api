using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Streetwood.Core.Constants;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Queries.Models.Shipment;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Shipment
{
    public class GetShipmentsQueryHandler : IRequestHandler<GetShipmentsQueryModel, IList<ShipmentDto>>
    {
        private readonly IShipmentQueryService shipmentQueryService;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly ICache cache;

        public GetShipmentsQueryHandler(IShipmentQueryService shipmentQueryService, IHttpContextAccessor contextAccessor, ICache cache)
        {
            this.shipmentQueryService = shipmentQueryService;
            this.contextAccessor = contextAccessor;
            this.cache = cache;
        }

        public async Task<IList<ShipmentDto>> Handle(GetShipmentsQueryModel request, CancellationToken cancellationToken)
        {
            var userType = contextAccessor.HttpContext.User.GetUserType();
            var result = await cache.GetOrCreateAsync(CacheKey.Shipments, s => shipmentQueryService.GetAsync(), userType);

            return result;
        }
    }
}
