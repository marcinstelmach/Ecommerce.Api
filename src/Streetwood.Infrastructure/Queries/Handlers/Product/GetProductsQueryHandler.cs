using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.Product;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Product
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryModel, IList<ProductListDto>>
    {
        private readonly IProductQueryService productQueryService;
        private readonly IMemoryCache cache;

        public GetProductsQueryHandler(IProductQueryService productQueryService, IMemoryCache cache)
        {
            this.productQueryService = productQueryService;
            this.cache = cache;
        }

        public async Task<IList<ProductListDto>> Handle(GetProductsQueryModel request, CancellationToken cancellationToken)
        {
            var result = await cache.GetOrCreateAsync(CacheKey.ProductList, e =>
            {
                e.SlidingExpiration = TimeSpan.FromMinutes(2);
                return productQueryService.GetProducts();
            });
            return result;
        }
    }
}
