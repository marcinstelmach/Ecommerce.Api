using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Exceptions;
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
        {
            var orderDto = await orderQueryService.GetAsync(request.Id);
            if (request.UserType == UserType.Admin)
            {
                return orderDto;
            }

            if (orderDto.User.Id == request.UserId)
            {
                return orderDto;
            }

            throw new StreetwoodException(ErrorCode.NoAccess);
        }
    }
}
