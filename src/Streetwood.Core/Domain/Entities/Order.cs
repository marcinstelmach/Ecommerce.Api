using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class Order : Entity
    {
        private List<ProductOrder> productOrders = new List<ProductOrder>();

        public bool IsShipped { get; protected set; }

        public bool IsPayed { get; protected set; }

        public bool IsClosed { get; protected set; }

        public string Comment { get; protected set; }

        public decimal Price { get; protected set; }

        public decimal PriceWithShippment { get; protected set; }

        public DateTime CreationDateTime { get; protected set; }

        public DateTime? PayedDateTime { get; protected set; }

        public DateTime? ShippmentDateTime { get; protected set; }

        public DateTime? ClosedDateTime { get; protected set; }

        public virtual Shippment Shippment { get; protected set; }

        public virtual User User { get; protected set; }

        public virtual Discount Discount { get; protected set; }

        public virtual IReadOnlyCollection<ProductOrder> ProductOrders => productOrders;

        public Order(string comment, decimal price, Shippment shippment)
        {
            SetIsShipped(false);
            SetIsPayed(false);
            SetIsClosed(false);
            Comment = comment;
            Price = price;
            SetShippment(shippment);
            PriceWithShippment = Price + shippment.Price;
            CreationDateTime = DateTime.UtcNow;
        }

        protected Order()
        {
        }

        public void SetIsShipped(bool isShipped)
            => IsShipped = isShipped;

        public void SetIsPayed(bool isPayed)
            => IsPayed = isPayed;

        public void SetIsClosed(bool isClosed)
            => IsClosed = isClosed;

        public void SetPayedDateTime(DateTime dateTime)
            => PayedDateTime = dateTime;

        public void SetShippmentDateTime(DateTime dateTime)
            => ShippmentDateTime = dateTime;

        public void SetClosedDate(DateTime dateTime)
            => ClosedDateTime = dateTime;

        public void SetShippment(Shippment shippment)
            => Shippment = shippment;

        public void SetDiscount(Discount discount)
            => Discount = discount;

        public void AddProductOrder(ProductOrder productOrder)
            => productOrders.Add(productOrder);

        public void AddProductOrders(IEnumerable<ProductOrder> productOrderss)
            => productOrders.AddRange(productOrderss);
    }
}