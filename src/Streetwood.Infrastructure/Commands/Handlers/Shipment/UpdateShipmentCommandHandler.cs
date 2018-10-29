using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Commands.Models.Shipment;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Shipment
{
    public class UpdateShipmentCommandHandler : IRequestHandler<UpdateShipmentCommandModel, Unit>
    {
        private readonly IShipmentCommandService service;
        private readonly IMemoryCache cache;

        public UpdateShipmentCommandHandler(IShipmentCommandService service, IMemoryCache cache)
        {
            this.service = service;
            this.cache = cache;
        }

        public async Task<Unit> Handle(UpdateShipmentCommandModel request, CancellationToken cancellationToken)
        {
            await service.UpdateAsync(request.Id, request.Name, request.NameEng, request.Description, request.DescriptionEng, request.IsActive, request.Type);
            cache.Remove(CacheKey.Shipments);

            return Unit.Value;
        }
    }
}
