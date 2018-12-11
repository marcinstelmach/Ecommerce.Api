using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.OrderDiscount
{
    public class GetOrderDiscountsQueryModel : IRequest<IList<OrderDiscountDto>>
    {
    }
}
