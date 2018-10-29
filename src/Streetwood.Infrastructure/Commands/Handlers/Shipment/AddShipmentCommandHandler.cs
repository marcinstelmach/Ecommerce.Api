using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Commands.Models.Shipment;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Shipment
{
    public class AddShipmentCommandHandler : IRequestHandler<AddShipmentCommandModel, Unit>
    {
        private readonly IShipmentCommandService shipmentCommandService;
        private readonly IMemoryCache cache;

        public AddShipmentCommandHandler(IShipmentCommandService shipmentCommandService, IMemoryCache cache)
        {
            this.shipmentCommandService = shipmentCommandService;
            this.cache = cache;
        }

        public async Task<Unit> Handle(AddShipmentCommandModel request, CancellationToken cancellationToken)
        {
            await shipmentCommandService.AddAsync(request.Name, request.NameEng, request.Description,
                request.DescriptionEng, request.Price, request.IsActive, request.Type);
            cache.Remove(CacheKey.Shipments);

            return Unit.Value;
        }
    }
}
