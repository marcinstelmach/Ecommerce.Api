using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Filters;
using Streetwood.Infrastructure.Queries.Models.Order;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Order
{
    public class GetFilteredOrdersQueryHandler : IRequestHandler<GetFilteredOrdersQueryModel, IEnumerable<OrderOverviewDto>>
    {
        private readonly IOrderQueryService orderQueryService;

        public GetFilteredOrdersQueryHandler(IOrderQueryService orderQueryService)
        {
            this.orderQueryService = orderQueryService;
        }

        public async Task<IEnumerable<OrderOverviewDto>> Handle(GetFilteredOrdersQueryModel request, CancellationToken cancellationToken)
        {
            var filter = new OrderQueryFilter(request);
            var result = await orderQueryService.GetFilteredAsync(filter);

            return result;
        }
    }
}