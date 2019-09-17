using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.OrderDiscount
{
    public class GetOrderDiscountByCodeQueryModel : IRequest<OrderDiscountDto>
    {
        public GetOrderDiscountByCodeQueryModel(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}