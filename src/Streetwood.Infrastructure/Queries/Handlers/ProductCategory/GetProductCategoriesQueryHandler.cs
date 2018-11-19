using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Queries.Models.ProductCategory;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.ProductCategory
{
    public class GetProductCategoriesQueryHandler : IRequestHandler<GetProductCategoriesQueryModel, IList<ProductCategoryDto>>
    {
        private readonly IProductCategoryQueryService productCategoryQueryService;
        private readonly ICache cache;

        public GetProductCategoriesQueryHandler(IProductCategoryQueryService productCategoryQueryService, ICache cache)
        {
            this.productCategoryQueryService = productCategoryQueryService;
            this.cache = cache;
        }

        public async Task<IList<ProductCategoryDto>> Handle(GetProductCategoriesQueryModel request, CancellationToken cancellationToken)
        {
            var result = await cache.GetOrCreateAsync(CacheKey.ProductCategoryTree, entry => productCategoryQueryService.GetAsync());

            return result;
        }
    }
}
