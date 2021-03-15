using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class Order : Entity
    {
        private readonly List<ProductOrder> productOrders = new List<ProductOrder>();

        public Order(User user, IEnumerable<ProductOrder> productOrders, OrderDiscount orderDiscount, Shipment shipment, Payment payment,
            decimal basePrice, decimal finalPrice, string comment, Address address)
        {
            IsClosed = false;
            Comment = comment;
            BasePrice = basePrice;
            SetShipment(shipment);
            SetPayment(payment);
            CreationDateTime = DateTimeOffset.UtcNow;
            AddProductOrders(productOrders);
            SetDiscount(orderDiscount);
            SetAddress(address);
            FinalPrice = finalPrice;
            SetUser(user);
            DiscountValue = orderDiscount?.PercentValue;
        }

        protected Order()
        {
        }

        public new int Id { get; set; }

        public bool IsClosed { get; protected set; }

        public string Comment { get; protected set; }

        public decimal BasePrice { get; protected set; }

        public decimal FinalPrice { get; protected set; }

        public int? DiscountValue { get; protected set; }

        public DateTimeOffset CreationDateTime { get; protected set; }

        public DateTimeOffset? ClosedDateTime { get; protected set; }

        public virtual User User { get; protected set; }

        public virtual OrderDiscount OrderDiscount { get; protected set; }

        public virtual Address Address { get; protected set; }

        public virtual OrderShipment OrderShipment { get; protected set; }

        public virtual OrderPayment OrderPayment { get; protected set; }

        public virtual IReadOnlyCollection<ProductOrder> ProductOrders => productOrders;

        public void Close()
        {
            IsClosed = true;
            ClosedDateTime = DateTimeOffset.UtcNow;
        }

        public void SetShipment(Shipment shipment)
        {
            OrderShipment = new OrderShipment(shipment);
        }

        public void SetPayment(Payment payment)
        {
            OrderPayment = new OrderPayment(payment);
        }

        public void SetDiscount(OrderDiscount discount)
            => OrderDiscount = discount;

        public void SetAddress(Address address)
            => Address = address;

        public void SetUser(User user)
            => User = user;

        public void AddProductOrders(IEnumerable<ProductOrder> productOrders)
            => this.productOrders.AddRange(productOrders);
    }
}