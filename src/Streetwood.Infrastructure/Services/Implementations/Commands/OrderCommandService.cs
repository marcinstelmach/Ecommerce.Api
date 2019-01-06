using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class OrderCommandService : IOrderCommandService
    {
        private readonly ILogger logger;
        private readonly IOrderRepository orderRepository;

        public OrderCommandService(ILogger logger, IOrderRepository orderRepository)
        {
            this.logger = logger;
            this.orderRepository = orderRepository;
        }

        public async Task<Guid> AddOrderAsync(User user, IList<ProductOrder> productOrders, Shipment shipment,
            OrderDiscount orderDiscount, string comment, Address address)
        {
            var productNames = string.Join(", ", productOrders.Select(s => s.Product).Select(s => s.Name));
            logger.Info($"Creating new order for products: {productNames}");
            if (!productOrders.Any())
            {
                throw new StreetwoodException(ErrorCode.NoProductsForNewOrder);
            }

            var basePrice = productOrders.Sum(s => s.CurrentProductPrice);
            if (basePrice <= 0)
            {
                throw new StreetwoodException(ErrorCode.OrderBasePriceBelowZero);
            }

            var productPriceWithDiscount = productOrders.Sum(s => s.FinalPrice);
            var agreedPrice = basePrice;
            if (orderDiscount != null)
            {
                agreedPrice = productPriceWithDiscount * (orderDiscount.PercentValue / 100M);
            }

            var order = new Order(user, productOrders, orderDiscount, shipment, basePrice, agreedPrice, comment, address);
            logger.Info($"Trying add order {order.Id.ToString()},s with base price {basePrice}...");

            await orderRepository.AddAsync(order);
            await orderRepository.SaveChangesAsync();

            logger.Info($"Order id: {order.Id.ToString()} added successfully !!!");

            return order.Id;
        }
    }
}