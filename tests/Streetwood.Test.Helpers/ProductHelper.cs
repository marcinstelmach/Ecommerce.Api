using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class ProductHelper
    {
        public static Product GetProduct()
        {
            return new Product("Test", "Product", 35, "Description", 
                "Description", true, "xl", "");
        }
    }
}