using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.Product;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Product
{
    public class GetProductsByCategoryIdQueryHandler : IRequestHandler<GetProductsByCategoryIdQueryModel, IList<ProductDto>>
    {
        private readonly IProductQueryService productQueryService;
        private readonly IMemoryCache cache;

        public GetProductsByCategoryIdQueryHandler(IProductQueryService productQueryService, IMemoryCache cache)
        {
            this.productQueryService = productQueryService;
            this.cache = cache;
        }

        public async Task<IList<ProductDto>> Handle(GetProductsByCategoryIdQueryModel request, CancellationToken cancellationToken)
        {
            var result = await cache.GetOrAddAsync($"{CacheKey.ProductsByCategory}{request.CategoryId.ToString()}",
                s => productQueryService.GetByCategoryIdAsync(request.CategoryId));
            return result;
        }
    }
}
