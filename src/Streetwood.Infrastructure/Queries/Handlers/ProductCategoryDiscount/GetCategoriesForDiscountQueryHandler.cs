using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.ProductCategoryDiscount;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.ProductCategoryDiscount
{
    public class GetCategoriesForDiscountQueryHandler : IRequestHandler<GetCategoriesForDiscountQueryModel, IList<ProductsCategoriesForDiscountDto>>
    {
        private readonly IProductCategoryDiscountQueryService discountQueryService;

        public GetCategoriesForDiscountQueryHandler(IProductCategoryDiscountQueryService discountQueryService)
        {
            this.discountQueryService = discountQueryService;
        }

        public async Task<IList<ProductsCategoriesForDiscountDto>> Handle(GetCategoriesForDiscountQueryModel request, CancellationToken cancellationToken)
        {
            var result = await discountQueryService.GetCategoriesAsync(request.Id);

            return result;
        }
    }
}
