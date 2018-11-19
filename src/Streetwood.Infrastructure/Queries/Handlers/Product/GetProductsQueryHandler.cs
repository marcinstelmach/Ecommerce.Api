using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Queries.Models.Product;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Product
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryModel, IList<ProductListDto>>
    {
        private readonly IProductQueryService productQueryService;
        private readonly ICache cache;

        public GetProductsQueryHandler(IProductQueryService productQueryService, ICache cache)
        {
            this.productQueryService = productQueryService;
            this.cache = cache;
        }

        public async Task<IList<ProductListDto>> Handle(GetProductsQueryModel request, CancellationToken cancellationToken)
        {
            var result = await cache.GetOrCreateAsync(CacheKey.ProductList, s => productQueryService.GetAsync());
            return result;
        }
    }
}
