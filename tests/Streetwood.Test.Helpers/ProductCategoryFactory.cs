using System.Collections.Generic;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class ProductCategoryFactory
    {
        public ProductCategory GetProductCategory()
            => new ProductCategory("T-shirts", "T-shirts");

        public List<ProductCategory> GetProductCategories(int count)
        {
            var productCategories = new List<ProductCategory>();
            for (int i = 0; i < count; i++)
            {
                productCategories.Add(new ProductCategory($"ProductCategory {i}", $"ProductCategory {i}"));
            }

            return productCategories;
        }
    }
}