using Streetwood.Core.Domain.Entities;

namespace Streetwood.Infrastructure.Models
{
    public class ApplyDiscountsToProductsResult
    {
        public ApplyDiscountsToProductsResult(int productId, ProductCategoryDiscount productCategoryDiscount)
        {
            ProductId = productId;
            ProductCategoryDiscount = productCategoryDiscount;
        }

        public int ProductId { get; set; }

        public ProductCategoryDiscount ProductCategoryDiscount { get; set; }
    }
}