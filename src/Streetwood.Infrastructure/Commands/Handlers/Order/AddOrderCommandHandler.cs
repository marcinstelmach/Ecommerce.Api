using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Order;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Commands.Handlers.Order
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandModel, Unit>
    {
        private readonly IUserQueryService userQueryService;
        private readonly IShipmentQueryService shipmentQueryService;
        private readonly IOrderDiscountQueryService orderDiscountQueryService;
        private readonly IProductOrderQueryService productOrderQueryService;

        public AddOrderCommandHandler(IUserQueryService userQueryService, IShipmentQueryService shipmentQueryService,
            IOrderDiscountQueryService orderDiscountQueryService, IProductOrderQueryService productOrderQueryService)
        {
            this.userQueryService = userQueryService;
            this.shipmentQueryService = shipmentQueryService;
            this.orderDiscountQueryService = orderDiscountQueryService;
            this.productOrderQueryService = productOrderQueryService;
        }

        public async Task<Unit> Handle(AddOrderCommandModel request, CancellationToken cancellationToken)
        {
            // on this level we have everything validated and checked => no validation here
            var user = await userQueryService.GetByIdAsync(request.UserId);

            var productOrders = productOrderQueryService.CreateAsync(request.Products);

            var shipment = await shipmentQueryService.GetRawAsync(request.ShipmentId);
            var codePromoValue = await orderDiscountQueryService.GetRawByCodeAsync(request.PromoCode);

            // Add Order


            throw new NotImplementedException();
        }
    }
}