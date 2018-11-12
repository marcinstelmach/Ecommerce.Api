using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Commands.Models.Charm;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Charm
{
    public class DeleteCharmCommandHandler : IRequestHandler<DeleteCharmCommandModel, Unit>
    {
        private readonly ICharmCommandService charmCommandService;
        private readonly IMemoryCache cache;

        public DeleteCharmCommandHandler(ICharmCommandService charmCommandService, IMemoryCache cache)
        {
            this.charmCommandService = charmCommandService;
            this.cache = cache;
        }

        public async Task<Unit> Handle(DeleteCharmCommandModel request, CancellationToken cancellationToken)
        {
            await charmCommandService.DeleteAsync(request.Id);
            cache.Remove(CacheKey.CharmCategoriesList);

            return Unit.Value;
        }
    }
}
