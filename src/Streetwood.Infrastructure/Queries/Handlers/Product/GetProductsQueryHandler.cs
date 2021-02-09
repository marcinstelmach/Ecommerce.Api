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
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryModel, IList<ProductListDto>>
    {
        private readonly IProductQueryService productQueryService;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly ICache cache;

        public GetProductsQueryHandler(IProductQueryService productQueryService, IHttpContextAccessor contextAccessor, ICache cache)
        {
            this.productQueryService = productQueryService;
            this.contextAccessor = contextAccessor;
            this.cache = cache;
        }

        public async Task<IList<ProductListDto>> Handle(GetProductsQueryModel request, CancellationToken cancellationToken)
        {
            var userType = contextAccessor.HttpContext.User.GetUserType();
            var result = await cache.GetOrCreateAsync(CacheKey.ProductList, s => productQueryService.GetAsync(), userType);
            return result;
        }
    }
}
