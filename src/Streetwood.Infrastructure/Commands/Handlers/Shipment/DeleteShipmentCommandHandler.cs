using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Commands.Models.Shipment;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Shipment
{
    public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommandModel, Unit>
    {
        private readonly IShipmentCommandService service;
        private readonly IMemoryCache cache;

        public DeleteShipmentCommandHandler(IShipmentCommandService service, IMemoryCache cache)
        {
            this.service = service;
            this.cache = cache;
        }

        public async Task<Unit> Handle(DeleteShipmentCommandModel request, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(request.Id);
            cache.Remove(CacheKey.Shipments);
            return Unit.Value;
        }
    }
}
