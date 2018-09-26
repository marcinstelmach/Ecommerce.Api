using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class ProductCategory : Entity
    {
        private List<Product> products = new List<Product>();

        public string Name { get; protected set; }

        public virtual ProductCategoryDiscount ProductCategoryDiscount { get; protected set; }

        public virtual Category Category { get; protected set; }

        public virtual IReadOnlyCollection<Product> Products => products;

        public ProductCategory(string name)
        {
            Id = Guid.NewGuid();
            SetName(name);
        }

        protected ProductCategory()
        {
        }

        public void SetName(string name)
            => Name = name;

        public void AddProduct(Product product)
            => products.Add(product);
    }
}