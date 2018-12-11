using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.OrderDiscount;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.OrderDiscount
{
    public class GetOrderDiscountsQueryHandler : IRequestHandler<GetOrderDiscountsQueryModel, IList<OrderDiscountDto>>
    {
        private readonly IOrderDiscountQueryService orderDiscountQueryService;

        public GetOrderDiscountsQueryHandler(IOrderDiscountQueryService orderDiscountQueryService)
        {
            this.orderDiscountQueryService = orderDiscountQueryService;
        }

        public async Task<IList<OrderDiscountDto>> Handle(GetOrderDiscountsQueryModel request,
            CancellationToken cancellationToken)
            => await orderDiscountQueryService.GetAsync();
    }
}
