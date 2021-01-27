namespace Streetwood.Infrastructure.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Core.Domain.Entities;
    using Streetwood.Infrastructure.Services.Abstract;

    internal class OrderFactory : IOrderFactory
    {
        private readonly ILogger logger;
        private readonly IOrdersRepository ordersRepository;

        public OrderFactory(ILogger<IOrderFactory> logger, IOrdersRepository ordersRepository)
        {
            this.logger = logger;
            this.ordersRepository = ordersRepository;
        }

        public async Task<Order> CreateOrderAsync(User user, IList<ProductOrder> productOrders, Shipment shipment, Payment payment,
            OrderDiscount orderDiscount, string comment, Address address)
        {
            if (!productOrders.Any())
            {
                throw new ArgumentException("Empty product orders");
            }

            var productNames = string.Join(", ", productOrders.Select(s => s.Product).Select(s => s.Name));
            logger.LogInformation($"Creating new order for products: {productNames}");

            var basePrice = productOrders.Sum(s => (s.CurrentProductPrice + s.CharmsPrice) * s.Amount);
            if (basePrice <= 0)
            {
                throw new Exception("Order base price is below 0.");
            }

            var finalPrice = productOrders.Sum(s => s.FinalPrice * s.Amount);
            if (orderDiscount != null)
            {
                var discountValue = (orderDiscount.PercentValue / 100M) * finalPrice;
                finalPrice -= discountValue;
            }

            var order = new Order(user, productOrders, orderDiscount, shipment, payment, basePrice, finalPrice, comment, address);
            logger.LogInformation($"Trying add order {order.Id}, with base price {basePrice}...");

            await ordersRepository.AddAsync(order);
            await ordersRepository.SaveChangesAsync();

            logger.LogInformation($"Order id: {order.Id} added successfully !!!");

            return order;
        }
    }
}