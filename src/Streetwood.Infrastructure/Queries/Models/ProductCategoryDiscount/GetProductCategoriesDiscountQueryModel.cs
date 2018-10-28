using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.ProductCategoryDiscount
{
    public class GetProductCategoriesDiscountQueryModel : IRequest<IList<ProductCategoryDiscountDto>>
    {
    }
}
