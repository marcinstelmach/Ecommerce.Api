using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class ProductCategoryDiscount : DiscountEntity
    {
        private List<ProductCategory> productCategories = new List<ProductCategory>();

        public virtual IReadOnlyCollection<ProductCategory> ProductCategories { get; set; }

        public ProductCategoryDiscount(string name, string nameEng, string description, string descriptionEng, decimal percentValue, bool isActive, DateTime avaibleFrom, DateTime avaibleTo) 
            : base(name, nameEng, description, descriptionEng, percentValue, isActive, avaibleFrom, avaibleTo)
        {
        }

        protected ProductCategoryDiscount()
        {
        }

        public void AddProductCategory(ProductCategory productCategory)
            => productCategories.Add(productCategory);
    }
}