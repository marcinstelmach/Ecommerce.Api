using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.CharmCategory;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.CharmCategory
{
    public class GetCharmCategoriesWithCharmsQueryHandler : IRequestHandler<GetCharmCategoriesWithCharmsQueryModel, IList<CharmCategoryDto>>
    {
        private readonly ICharmCategoryQueryService charmCategoryQueryService;
        private readonly IMemoryCache cache;

        public GetCharmCategoriesWithCharmsQueryHandler(ICharmCategoryQueryService charmCategoryQueryService, IMemoryCache cache)
        {
            this.charmCategoryQueryService = charmCategoryQueryService;
            this.cache = cache;
        }

        public async Task<IList<CharmCategoryDto>> Handle(GetCharmCategoriesWithCharmsQueryModel request, CancellationToken cancellationToken)
        {
            var result = await cache.GetOrAddAsync(CacheKey.CharmCategoriesList, s => charmCategoryQueryService.GetAsync());

            return result;
        }
    }
}
