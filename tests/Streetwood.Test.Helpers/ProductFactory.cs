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
    }
}