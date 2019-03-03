using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class Order : Entity
    {
        private readonly List<ProductOrder> productOrders = new List<ProductOrder>();

        public new int Id { get; set; }

        public bool IsShipped { get; protected set; }

        public bool IsPayed { get; protected set; }

        public bool IsClosed { get; protected set; }

        public string Comment { get; protected set; }

        public decimal BasePrice { get; protected set; }

        public decimal ShipmentPrice { get; protected set; }

        public decimal FinalPrice { get; protected set; }

        public int? DiscountValue { get; protected set; }

        public DateTime CreationDateTime { get; protected set; }

        public DateTime? PayedDateTime { get; protected set; }

        public DateTime? ShipmentDateTime { get; protected set; }

        public DateTime? ClosedDateTime { get; protected set; }

        public virtual Shipment Shipment { get; protected set; }

        public virtual User User { get; protected set; }

        public virtual OrderDiscount OrderDiscount { get; protected set; }

        public virtual Address Address { get; protected set; }

        public virtual IReadOnlyCollection<ProductOrder> ProductOrders => productOrders;

        public Order(User user, IEnumerable<ProductOrder> productOrders, OrderDiscount orderDiscount, Shipment shipment,
            decimal basePrice, decimal finalPrice, string comment, Address address)
        {
            SetIsShipped(false);
            SetIsPayed(false);
            SetIsClosed(false);
            Comment = comment;
            BasePrice = basePrice;
            SetShipment(shipment);
            ShipmentPrice = shipment.Price;
            CreationDateTime = DateTime.UtcNow;
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

        public void SetIsShipped(bool isShipped)
        {
            if (isShipped == IsShipped)
            {
                return;
            }

            IsShipped = isShipped;
            SetShipmentDateTime(DateTime.UtcNow);
        }

        public void SetIsPayed(bool isPayed)
        {
            if (isPayed == IsPayed)
            {
                return;
            }

            IsPayed = isPayed;
            SetPayedDateTime(DateTime.UtcNow);
        }

        public void SetIsClosed(bool isClosed)
        {
            if (isClosed == IsClosed)
            {
                return;
            }

            IsClosed = isClosed;
            SetClosedDate(DateTime.UtcNow);
        }

        public void SetPayedDateTime(DateTime dateTime)
            => PayedDateTime = dateTime;

        public void SetShipmentDateTime(DateTime dateTime)
            => ShipmentDateTime = dateTime;

        public void SetClosedDate(DateTime dateTime)
            => ClosedDateTime = dateTime;

        public void SetShipment(Shipment shipment)
            => Shipment = shipment;

        public void SetDiscount(OrderDiscount discount)
            => OrderDiscount = discount;

        public void SetAddress(Address address)
            => Address = address;

        public void SetUser(User user)
            => User = user;

        public void AddProductOrder(ProductOrder productOrder)
            => productOrders.Add(productOrder);

        public void AddProductOrders(IEnumerable<ProductOrder> productOrderss)
            => this.productOrders.AddRange(productOrderss);
    }
}