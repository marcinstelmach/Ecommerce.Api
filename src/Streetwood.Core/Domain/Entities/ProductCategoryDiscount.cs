using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class ProductCategoryDiscount : DiscountEntity
    {
        private List<ProductCategory> productCategories = new List<ProductCategory>();
        private List<ProductOrder> productOrders = new List<ProductOrder>();

        public virtual IList<ProductCategory> ProductCategories => productCategories;

        public virtual IReadOnlyCollection<ProductOrder> ProductOrders => productOrders;

        public ProductCategoryDiscount(string name, string nameEng, string description, string descriptionEng, int percentValue, bool isActive, DateTime avaibleFrom, DateTime avaibleTo)
            : base(name, nameEng, description, descriptionEng, percentValue, isActive, avaibleFrom, avaibleTo)
        {
        }

        protected ProductCategoryDiscount()
        {
        }

        public void AddProductCategory(IEnumerable<ProductCategory> productCategories)
            => this.productCategories.AddRange(productCategories);

    }
}