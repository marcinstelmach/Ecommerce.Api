using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.ProductCategory;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.ProductCategory
{
    public class GetProductCategoriesQueryHandler : IRequestHandler<GetProductCategoriesQueryModel, IList<ProductCategoryDto>>
    {
        private readonly IProductCategoryQueryService productCategoryQueryService;
        private readonly IMemoryCache cache;

        public GetProductCategoriesQueryHandler(IProductCategoryQueryService productCategoryQueryService, IMemoryCache cache)
        {
            this.productCategoryQueryService = productCategoryQueryService;
            this.cache = cache;
        }

        public async Task<IList<ProductCategoryDto>> Handle(GetProductCategoriesQueryModel request, CancellationToken cancellationToken)
        {
            var result = await cache.GetOrAddAsync(CacheKey.ProductCategoryTree, entry => productCategoryQueryService.GetAsync());

            return result;
        }
    }
}
