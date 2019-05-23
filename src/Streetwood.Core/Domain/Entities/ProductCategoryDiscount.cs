using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class ProductCategoryDiscount : DiscountEntity
    {
        private readonly List<DiscountCategory> discountCategories = new List<DiscountCategory>();
        private readonly List<ProductOrder> productOrders = new List<ProductOrder>();

        public virtual IList<DiscountCategory> DiscountCategories => discountCategories;

        public virtual IReadOnlyCollection<ProductOrder> ProductOrders => productOrders;

        public ProductCategoryDiscount(string name, string nameEng, string description, string descriptionEng, int percentValue, DateTime availableFrom, DateTime availableTo)
            : base(name, nameEng, description, descriptionEng, percentValue, availableFrom, availableTo)
        {
        }

        protected ProductCategoryDiscount()
        {
        }

        public void AddProductCategory(IEnumerable<DiscountCategory> discountCategoriess)
            => this.discountCategories.AddRange(discountCategoriess);
    }
}