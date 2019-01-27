using System;

namespace Streetwood.Core.Constants
{
    public static class CacheKey
    {
        public static string ProductCategoryTree => nameof(ProductCategoryTree);

        public static string Shipments => nameof(Shipments);

        public static string ProductList => nameof(ProductList);

        public static string ProductsByCategory(Guid id) => $"{nameof(ProductsByCategory)}{id.ToString()}";

        public static string ProductCategoryDiscountList => nameof(ProductCategoryDiscountList);

        public static string CharmCategoriesList => nameof(CharmCategoriesList);

        public static string ProductsWithDiscounts(Guid id) => $"{nameof(ProductsWithDiscounts)}{id.ToString()}";
    }
}
