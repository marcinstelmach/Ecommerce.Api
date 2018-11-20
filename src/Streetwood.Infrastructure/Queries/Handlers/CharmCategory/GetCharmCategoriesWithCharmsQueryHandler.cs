using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Streetwood.Core.Constants;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Queries.Models.CharmCategory;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.CharmCategory
{
    public class GetCharmCategoriesWithCharmsQueryHandler : IRequestHandler<GetCharmCategoriesWithCharmsQueryModel, IList<CharmCategoryDto>>
    {
        private readonly ICharmCategoryQueryService charmCategoryQueryService;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly ICache cache;

        public GetCharmCategoriesWithCharmsQueryHandler(ICharmCategoryQueryService charmCategoryQueryService, IHttpContextAccessor contextAccessor, ICache cache)
        {
            this.charmCategoryQueryService = charmCategoryQueryService;
            this.contextAccessor = contextAccessor;
            this.cache = cache;
        }

        public async Task<IList<CharmCategoryDto>> Handle(GetCharmCategoriesWithCharmsQueryModel request, CancellationToken cancellationToken)
        {
            var userType = contextAccessor.HttpContext.User.GetUserType();
            var result = await cache.GetOrCreateAsync(CacheKey.CharmCategoriesList, s => charmCategoryQueryService.GetAsync(), userType);

            return result;
        }
    }
}
