using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class ProductCategoryDiscount : DiscountEntity
    {
        private List<DiscountCategory> discountCategories = new List<DiscountCategory>();
        private List<ProductOrder> productOrders = new List<ProductOrder>();

        public virtual IList<DiscountCategory> DiscountCategories => discountCategories;

        public virtual IReadOnlyCollection<ProductOrder> ProductOrders => productOrders;

        public ProductCategoryDiscount(string name, string nameEng, string description, string descriptionEng, int percentValue, bool isActive, DateTime availableFrom, DateTime avaibleTo)
            : base(name, nameEng, description, descriptionEng, percentValue, isActive, availableFrom, avaibleTo)
        {
        }

        protected ProductCategoryDiscount()
        {
        }

        public void AddProductCategory(IEnumerable<DiscountCategory> discountCategories)
            => this.discountCategories.AddRange(discountCategories);

    }
}