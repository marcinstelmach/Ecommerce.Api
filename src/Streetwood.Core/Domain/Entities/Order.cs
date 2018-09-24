using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class Order : Entity
    {
        public int UserId { get; set; }

        public int AddressId { get; set; }

        public int? DiscountId { get; set; }

        public bool IsShipped { get; set; }

        public bool IsPayed { get; set; }

        public bool IsClosed { get; set; }

        public string Comment { get; set; }

        public decimal ShippmentPrice { get; set; }

        public decimal Price { get; set; }

        public DateTime CreationDateTime { get; set; }

        public DateTime? PayedDateTime { get; set; }

        public DateTime? ShippmentDateTime { get; set; }

        public DateTime? ClosedDateTime { get; set; }

        public Shippment Shippment { get; set; }

        public User User { get; set; }

        public Address Address { get; set; }

        public Discount Discount { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}