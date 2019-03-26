using System.Collections.Generic;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class ProductFactory
    {
        public static Product GetProductWithoutCharms()
            => new Product("Some shirt", "Product", 99, "Description",
                "Description", false, "xl", "");

        public static Product GetProductWithCharms()
            => new Product("Red anchor", "Red anchor", 30, "Description",
                "Eng description", true, "", "");

        public static List<Product> GetNonCharmProducts(int count)
        {
            var products = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                products.Add(new Product($"Product{i}", $"Product{i}", 35 + i, "Some product description",
                    "Some product description", false, "s,m,l,xl", ""));
            }

            return products;
        }
    }
}