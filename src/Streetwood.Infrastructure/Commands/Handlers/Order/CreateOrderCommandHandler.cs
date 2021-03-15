namespace Streetwood.Infrastructure.Commands.Handlers.Order
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Core.Domain.Enums;
    using Streetwood.Core.Exceptions;
    using Streetwood.Infrastructure.Commands.Models.Order;
    using Streetwood.Infrastructure.Services.Abstract;
    using Streetwood.Infrastructure.Services.Abstract.Queries;

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandModel, int>
    {
        private readonly IUserQueryService userQueryService;
        private readonly IShipmentQueryService shipmentQueryService;
        private readonly IOrderDiscountQueryService orderDiscountQueryService;
        private readonly IProductOrderQueryService productOrderQueryService;
        private readonly IAddressQueryService addressQueryService;
        private readonly IOrderFactory orderFactory;
        private readonly IEmailService emailService;
        private readonly IPaymentsRepository paymentsRepository;

        public CreateOrderCommandHandler(IUserQueryService userQueryService, IShipmentQueryService shipmentQueryService,
            IOrderDiscountQueryService orderDiscountQueryService, IProductOrderQueryService productOrderQueryService,
            IAddressQueryService addressQueryService, IOrderFactory orderFactory, IEmailService emailService,
            IPaymentsRepository paymentsRepository)
        {
            this.userQueryService = userQueryService;
            this.shipmentQueryService = shipmentQueryService;
            this.orderDiscountQueryService = orderDiscountQueryService;
            this.productOrderQueryService = productOrderQueryService;
            this.orderFactory = orderFactory;
            this.addressQueryService = addressQueryService;
            this.emailService = emailService;
            this.paymentsRepository = paymentsRepository;
        }

        public async Task<int> Handle(CreateOrderCommandModel request, CancellationToken cancellationToken)
        {
            var user = await userQueryService.GetRawByIdAsync(request.UserId);
            var productOrders = await productOrderQueryService.CreateAsync(request.Products);
            var shipment = await shipmentQueryService.GetRawAsync(request.ShipmentId);
            var payment = await paymentsRepository.GetPaymentAsync(request.PaymentId);
            if ((shipment.Type == ShipmentType.CashOnDelivery && payment.PaymentType != PaymentType.PaymentOnDelivery)
                || (shipment.Type != ShipmentType.CashOnDelivery && payment.PaymentType == PaymentType.PaymentOnDelivery))
            {
                throw new StreetwoodException(ErrorCode.InvalidShipmentType);
            }

            var orderDiscount = await orderDiscountQueryService.GetRawByCodeAsync(request.PromoCode);
            var address = await addressQueryService.GetAsync(request.Address, request.AddressId, request.UserId);

            var order = await orderFactory.CreateOrderAsync(user, productOrders, shipment, payment, orderDiscount, request.Comment, address);
            await emailService.SendNewOrderEmailAsync(order);

            return order.Id;
        }
    }
}