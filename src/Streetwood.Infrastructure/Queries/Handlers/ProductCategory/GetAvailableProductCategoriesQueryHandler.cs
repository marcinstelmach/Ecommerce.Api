using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Streetwood.Core.Constants;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Queries.Models.ProductCategory;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.ProductCategory
{
    public class GetAvailableProductCategoriesQueryHandler : IRequestHandler<GetAvailableProductCategoriesQueryModel, IList<ProductCategoryDto>>
    {
        private readonly IProductCategoryQueryService productCategoryQueryService;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly ICache cache;

        public GetAvailableProductCategoriesQueryHandler(IProductCategoryQueryService productCategoryQueryService, IHttpContextAccessor contextAccessor, ICache cache)
        {
            this.productCategoryQueryService = productCategoryQueryService;
            this.contextAccessor = contextAccessor;
            this.cache = cache;
        }

        public async Task<IList<ProductCategoryDto>> Handle(GetAvailableProductCategoriesQueryModel request, CancellationToken cancellationToken)
        {
            var userType = contextAccessor.HttpContext.User.GetUserType();
            var result = await cache.GetOrCreateAsync(CacheKey.ProductCategoryTree, entry => productCategoryQueryService.GetAvailableAsync(), userType);

            return result;
        }
    }
}
