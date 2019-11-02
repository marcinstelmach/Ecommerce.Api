using Streetwood.Core.Domain.Entities;

namespace Streetwood.Infrastructure.Models
{
    public class ApplyCharmsToProductOrderResult
    {
        public ApplyCharmsToProductOrderResult(ProductOrder productOrder, decimal finalPrice)
        {
            ProductOrder = productOrder;
            FinalPrice = finalPrice;
        }

        public ProductOrder ProductOrder { get; set; }

        public decimal FinalPrice { get; set; }
    }
}