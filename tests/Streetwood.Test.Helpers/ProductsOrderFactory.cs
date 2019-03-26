using System.Collections.Generic;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class ProductsOrderFactory
    {
        public static List<ProductOrder> GetProductsOrders()
        {
            var productOrder = new ProductOrder(2, "Product order comment");
            productOrder.AddProduct(ProductFactory.GetProductWithoutCharms());
            productOrder.SetFinalPrice(99);

            var productOrderWitchCharm = new ProductOrder(1, "Please give give");
            productOrderWitchCharm.AddProduct(ProductFactory.GetProductWithCharms());
            productOrderWitchCharm.AddProductOrderCharms(ProductOrderCharmsFactory.GetProductOrderCharms(3));
            productOrderWitchCharm.SetFinalPrice(40);

            return new List<ProductOrder>
            {
                productOrder,
                productOrderWitchCharm
            };
        }

        public static List<ProductOrder> GetProductOrdersWithDiscounts()
        {
            var productOrders = GetProductsOrders();
            var productOrderWithDiscount = new ProductOrder(3, "Product order with discount");
            productOrderWithDiscount.AddProduct(ProductFactory.GetProductWithCharms());
            productOrderWithDiscount.AddProductOrderCharms(ProductOrderCharmsFactory.GetProductOrderCharms(5));
            productOrderWithDiscount.AddProductCategoryDiscount(DiscountFactory.GetProductCategoryDiscount());

            productOrders.Add(productOrderWithDiscount);
            return productOrders;
        }
    }
}
