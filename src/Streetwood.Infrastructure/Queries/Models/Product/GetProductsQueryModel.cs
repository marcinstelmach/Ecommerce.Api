using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Product
{
    public class GetProductsQueryModel : IRequest<IList<ProductListDto>>
    {
    }
}
