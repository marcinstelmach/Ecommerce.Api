using System.Collections.Generic;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class ProductsOrderHelper
    {
        public static IEnumerable<ProductOrder> GetProductsOrders()
        {
            var productOrder = new ProductOrder(5, "Product order comment");
            productOrder.AddProduct(ProductHelper.GetProduct());

            return new List<ProductOrder>
            {
                productOrder
            };
        }
    }
}
