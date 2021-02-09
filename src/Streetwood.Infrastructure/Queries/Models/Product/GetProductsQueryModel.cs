using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Dto.Products;

namespace Streetwood.Infrastructure.Queries.Models.Product
{
    public class GetProductsQueryModel : IRequest<IList<ProductListDto>>
    {
    }
}
