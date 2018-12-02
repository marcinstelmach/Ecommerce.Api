using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.ProductCategoryDiscount;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.ProductCategoryDiscount
{
    public class GetProductCategoryDiscountQueryHandler : IRequestHandler<GetProductCategoryDiscountQueryModel, ProductCategoryDiscountWithDataDto>
    {
        private readonly IProductCategoryDiscountQueryService discountQueryService;

        public GetProductCategoryDiscountQueryHandler(IProductCategoryDiscountQueryService discountQueryService)
        {
            this.discountQueryService = discountQueryService;
        }

        public async Task<ProductCategoryDiscountWithDataDto> Handle(GetProductCategoryDiscountQueryModel request, CancellationToken cancellationToken)
        {
            var result = await discountQueryService.GetWithDataAsync(request.Id);
            return result;
        }
    }
}
