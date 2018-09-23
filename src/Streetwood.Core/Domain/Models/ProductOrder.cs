using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Models
{
    public class ProductOrder : Entity
    {
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public decimal CurrentPrice { get; set; }
        public int? DiscountId { get; set; }
        public string Comment { get; set; }
        public Discount Discount { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public ICollection<ProductOrderCharm> ProductOrderCharms { get; set; }
    }
}