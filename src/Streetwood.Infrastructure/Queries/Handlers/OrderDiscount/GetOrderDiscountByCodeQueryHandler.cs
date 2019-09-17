using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.OrderDiscount;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.OrderDiscount
{
    public class GetOrderDiscountByCodeQueryHandler : IRequestHandler<GetOrderDiscountByCodeQueryModel, OrderDiscountDto>
    {
        private readonly IOrderDiscountQueryService orderDiscountQueryService;

        public GetOrderDiscountByCodeQueryHandler(IOrderDiscountQueryService orderDiscountQueryService)
        {
            this.orderDiscountQueryService = orderDiscountQueryService;
        }

        public async Task<OrderDiscountDto> Handle(GetOrderDiscountByCodeQueryModel request, CancellationToken cancellationToken)
            => await orderDiscountQueryService.GetByCodeAsync(request.Code);
    }
}