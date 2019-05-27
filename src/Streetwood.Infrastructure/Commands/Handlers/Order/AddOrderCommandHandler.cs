using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Commands.Models.Order;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract;
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
        private readonly IAddressQueryService addressQueryService;
        private readonly IOrderCommandService orderCommandService;
        private readonly IEmailService emailService;
        private readonly IMapper mapper;

        public AddOrderCommandHandler(IUserQueryService userQueryService, IShipmentQueryService shipmentQueryService,
            IOrderDiscountQueryService orderDiscountQueryService, IProductOrderQueryService productOrderQueryService,
            IAddressQueryService addressQueryService, IOrderCommandService orderCommandService, IEmailService emailService,
            IMapper mapper)
        {
            this.userQueryService = userQueryService;
            this.shipmentQueryService = shipmentQueryService;
            this.orderDiscountQueryService = orderDiscountQueryService;
            this.productOrderQueryService = productOrderQueryService;
            this.orderCommandService = orderCommandService;
            this.addressQueryService = addressQueryService;
            this.emailService = emailService;
            this.mapper = mapper;
        }

        public async Task<int> Handle(AddOrderCommandModel request, CancellationToken cancellationToken)
        {
            // on this level we have everything validated and checked => no validation here
            var user = await userQueryService.GetRawByIdAsync(request.UserId);
            var productOrders = await productOrderQueryService.CreateAsync(request.Products);
            var shipment = await shipmentQueryService.GetRawAsync(request.ShipmentId);
            var orderDiscount = await orderDiscountQueryService.GetRawByCodeAsync(request.PromoCode);
            var address = await addressQueryService.GetAsync(request.Address, request.AddressId, request.UserId); 

            var order = await orderCommandService.AddAsync(user, productOrders, shipment, orderDiscount, request.Comment, address);
            await emailService.SendNewOrderEmailAsync(mapper.Map<OrderDto>(order));

            return order.Id;
        }
    }
}