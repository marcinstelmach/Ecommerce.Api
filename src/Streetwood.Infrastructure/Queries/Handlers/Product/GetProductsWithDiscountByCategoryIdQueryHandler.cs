using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Streetwood.Core.Constants;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Queries.Models.Product;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Product
{
    public class GetProductsWithDiscountByCategoryIdQueryHandler : IRequestHandler<GetProductsWithDiscountByCategoryIdQueryModel, IList<ProductWithDiscountDto>>
    {
        private readonly IProductQueryService productQueryService;
        private readonly ICache cache;
        private readonly IHttpContextAccessor httpContextAccessor;

        public GetProductsWithDiscountByCategoryIdQueryHandler(IProductQueryService productQueryService, ICache cache, IHttpContextAccessor httpContextAccessor)
        {
            this.productQueryService = productQueryService;
            this.cache = cache;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IList<ProductWithDiscountDto>> Handle(GetProductsWithDiscountByCategoryIdQueryModel request, CancellationToken cancellationToken)
        {
            var userType = httpContextAccessor.HttpContext.User.GetUserType();
            return await cache.GetOrCreateAsync(CacheKey.ProductsWithDiscounts(request.CategoryId),
                s => productQueryService.GetAvailableWithDiscountByCategoryIdAsync(request.CategoryId), userType);
        }
    }
}
