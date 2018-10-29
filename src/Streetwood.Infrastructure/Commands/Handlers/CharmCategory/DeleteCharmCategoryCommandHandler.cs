using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Commands.Models.CharmCategory;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.CharmCategory
{
    public class DeleteCharmCategoryCommandHandler : IRequestHandler<DeleteCharmCategoryCommandModel, Unit>
    {
        private readonly ICharmCategoryCommandService charmCategoryCommandService;
        private readonly IMemoryCache cache;

        public DeleteCharmCategoryCommandHandler(ICharmCategoryCommandService charmCategoryCommandService, IMemoryCache cache)
        {
            this.charmCategoryCommandService = charmCategoryCommandService;
            this.cache = cache;
        }

        public async Task<Unit> Handle(DeleteCharmCategoryCommandModel request, CancellationToken cancellationToken)
        {
            await charmCategoryCommandService.DeleteAsync(request.Id);
            cache.Remove(CacheKey.CharmCategoriesList);
            return Unit.Value;
        }
    }
}
