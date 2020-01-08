using System.Collections.Generic;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class ProductsOrderFactory
    {
        public static List<ProductOrder> GetProductsOrders()
        {
            var productOrder = new ProductOrder(2, "Product order comment", "L", "Red");
            productOrder.AddProduct(ProductFactory.GetProductWithoutCharms());
            productOrder.SetFinalPrice(99);

            var productOrderWitchCharm = new ProductOrder(1, "Please give give", "L", "White");
            productOrderWitchCharm.AddProduct(ProductFactory.GetProductWithCharms());
            productOrderWitchCharm.AddProductOrderCharms(ProductOrderCharmsFactory.GetProductOrderCharms(3));
            productOrderWitchCharm.SetFinalPrice(40);

            return new List<ProductOrder>
            {
                productOrder,
                productOrderWitchCharm
            };
        }
    }
}
