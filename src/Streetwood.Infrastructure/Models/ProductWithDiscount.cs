using Streetwood.Core.Domain.Entities;

namespace Streetwood.Infrastructure.Models
{
    public class ProductWithDiscount
    {
        public ProductWithDiscount(Product product, ProductCategoryDiscount productCategoryDiscount)
        {
            Product = product;
            ProductCategoryDiscount = productCategoryDiscount;
        }

        public Product Product { get; set; }

        public ProductCategoryDiscount ProductCategoryDiscount { get; set; }
    }
}