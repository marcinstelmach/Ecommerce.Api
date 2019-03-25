using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Order;
using Streetwood.Infrastructure.Services.Abstract.Commands;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Commands.Handlers.Order
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandModel, int>
    {
        private readonly IUserQueryService userQueryService;
        private readonly IShipmentQueryService shipmentQueryService;
        private readonly IOrderDiscountQueryService orderDiscountQueryService;
        private readonly IProductOrderQueryService productOrderQueryService;
        private readonly IOrderCommandService orderCommandService;

        public AddOrderCommandHandler(IUserQueryService userQueryService, IShipmentQueryService shipmentQueryService,
            IOrderDiscountQueryService orderDiscountQueryService, IProductOrderQueryService productOrderQueryService,
            IOrderCommandService orderCommandService)
        {
            this.userQueryService = userQueryService;
            this.shipmentQueryService = shipmentQueryService;
            this.orderDiscountQueryService = orderDiscountQueryService;
            this.productOrderQueryService = productOrderQueryService;
            this.orderCommandService = orderCommandService;
        }

        public async Task<int> Handle(AddOrderCommandModel request, CancellationToken cancellationToken)
        {
            // on this level we have everything validated and checked => no validation here
            var user = await userQueryService.GetRawByIdAsync(request.UserId);
            var productOrders = await productOrderQueryService.CreateAsync(request.Products);
            var shipment = await shipmentQueryService.GetRawAsync(request.ShipmentId);
            var orderDiscount = await orderDiscountQueryService.GetRawByCodeAsync(request.PromoCode);
            var address = new Core.Domain.Entities.Address(request.Address.Street, request.Address.City,
                request.Address.Country, request.Address.PostCode, request.Address.PhoneNumber);

            var orderId = await orderCommandService.AddAsync(user, productOrders, shipment, orderDiscount, request.Comment, address);
            return orderId;
        }
    }
}