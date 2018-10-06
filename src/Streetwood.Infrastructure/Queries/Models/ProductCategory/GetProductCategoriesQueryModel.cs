using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.ProductCategory
{
    public class GetProductCategoriesQueryModel : IRequest<IList<ProductCategoryDto>>
    {
    }
}
