using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class Category : Entity
    {
        private List<ProductCategory> productCategories = new List<ProductCategory>();

        public string Name { get; protected set; }

        public virtual IReadOnlyCollection<ProductCategory> ProductCategories => productCategories;

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        protected Category()
        {
        }

        public void AddProductCategory(ProductCategory productCategory)
            => productCategories.Add(productCategory);
    }
}
