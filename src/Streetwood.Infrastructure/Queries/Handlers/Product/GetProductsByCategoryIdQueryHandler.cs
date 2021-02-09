using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Streetwood.Core.Constants;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Dto.Products;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Queries.Models.Product;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Product
{
    public class GetProductsByCategoryIdQueryHandler : IRequestHandler<GetProductsByCategoryIdQueryModel, IList<ProductDto>>
    {
        private readonly IProductQueryService productQueryService;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly ICache cache;

        public GetProductsByCategoryIdQueryHandler(IProductQueryService productQueryService, IHttpContextAccessor contextAccessor, ICache cache)
        {
            this.productQueryService = productQueryService;
            this.contextAccessor = contextAccessor;
            this.cache = cache;
        }

        public async Task<IList<ProductDto>> Handle(GetProductsByCategoryIdQueryModel request, CancellationToken cancellationToken)
        {
            var userType = contextAccessor.HttpContext.User.GetUserType();
            var result = await cache.GetOrCreateAsync(CacheKey.ProductsByCategory(request.CategoryId),
                s => productQueryService.GetAvailableByCategoryIdAsync(request.CategoryId), userType);
            return result;
        }
    }
}
