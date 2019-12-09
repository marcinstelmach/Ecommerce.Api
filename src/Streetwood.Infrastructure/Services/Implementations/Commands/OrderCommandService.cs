using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class OrderCommandService : IOrderCommandService
    {
        private readonly ILogger logger;
        private readonly IOrderRepository orderRepository;
        private readonly IEmailService emailService;
        private readonly IMapper mapper;

        public OrderCommandService(ILogger<IOrderCommandService> logger, IOrderRepository orderRepository, IEmailService emailService, IMapper mapper)
        {
            this.logger = logger;
            this.orderRepository = orderRepository;
            this.emailService = emailService;
            this.mapper = mapper;
        }

        public async Task<Order> AddAsync(User user, IList<ProductOrder> productOrders, Shipment shipment,
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

            var order = new Order(user, productOrders, orderDiscount, shipment, basePrice, finalPrice, comment, address);
            logger.LogInformation($"Trying add order {order.Id}, with base price {basePrice}...");

            await orderRepository.AddAsync(order);
            await orderRepository.SaveChangesAsync();

            logger.LogInformation($"Order id: {order.Id} added successfully !!!");

            return order;
        }

        public async Task UpdateAsync(int id, bool payed, bool shipped, bool closed)
        {
            var order = await orderRepository.GetAndEnsureExistAsync(id);
            var shippedBeforeSave = order.IsShipped;
            order.SetIsPayed(payed);
            order.SetIsShipped(shipped);
            order.SetIsClosed(closed);

            await orderRepository.SaveChangesAsync();

            if (!shippedBeforeSave && shipped)
            {
                var orderDto = mapper.Map<Order, OrderDto>(order);
                await emailService.SendOrderWasShippedEmailAsync(orderDto);
            }
        }
    }
}