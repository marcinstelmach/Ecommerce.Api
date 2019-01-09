using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.Order;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Order
{
    public class GetFilteredOrdersQueryHandler : IRequestHandler<GetFilteredOrdersQueryModel, IEnumerable<OrderDto>>
    {
        private readonly IOrderQueryService orderQueryService;

        public GetFilteredOrdersQueryHandler(IOrderQueryService orderQueryService)
        {
            this.orderQueryService = orderQueryService;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetFilteredOrdersQueryModel request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
