using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.Order;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Order
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQueryModel, OrderDto>
    {
        private readonly IOrderQueryService orderQueryService;

        public GetOrderQueryHandler(IOrderQueryService orderQueryService)
        {
            this.orderQueryService = orderQueryService;
        }

        public async Task<OrderDto> Handle(GetOrderQueryModel request, CancellationToken cancellationToken)
            => await orderQueryService.GetAsync(request.Id);
    }
}
