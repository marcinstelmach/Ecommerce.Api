using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Queries.Models.ProductCategoryDiscount;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.ProductCategoryDiscount
{
    public class GetProductCategoriesDiscountQueryHandler : IRequestHandler<GetProductCategoriesDiscountQueryModel, IList<ProductCategoryDiscountDto>>
    {
        private readonly IProductCategoryDiscountQueryService service;
        private readonly ICache cache;

        public GetProductCategoriesDiscountQueryHandler(IProductCategoryDiscountQueryService service, ICache cache)
        {
            this.service = service;
            this.cache = cache;
        }

        public async Task<IList<ProductCategoryDiscountDto>> Handle(GetProductCategoriesDiscountQueryModel request, CancellationToken cancellationToken)
        {
            var result = await cache.GetOrCreateAsync(CacheKey.ProductCategoryDiscountList, s => service.GetAsync());
            return result;
        }
    }
}
