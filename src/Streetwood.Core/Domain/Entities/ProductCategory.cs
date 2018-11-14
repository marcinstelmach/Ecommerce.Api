using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Extensions;

namespace Streetwood.Core.Domain.Entities
{
    public class ProductCategory : Entity
    {
        private List<Product> products = new List<Product>();
        private List<ProductCategory> productCategories = new List<ProductCategory>();

        public string Name { get; protected set; }

        public string NameEng { get; protected set; }

        public string UniqueName { get; protected set; }

        public ItemStatus Status { get; protected set; }

        public virtual ProductCategoryDiscount ProductCategoryDiscount { get; protected set; }

        public virtual List<ProductCategory> ProductCategories => productCategories;

        public virtual IReadOnlyCollection<Product> Products => products;

        public virtual ProductCategory Parent { get; protected set; }

        public ProductCategory(string name, string nameEng)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetNameEng(nameEng);
            UniqueName = name.AppendRandom(5);
            SetStatus(ItemStatus.Available);
        }

        protected ProductCategory()
        {
        }

        public void SetName(string name)
            => Name = name;

        public void SetNameEng(string name)
            => NameEng = name;

        public void SetStatus(ItemStatus status)
            => Status = status;

        public void AddProduct(Product product)
            => products.Add(product);

        public void AddCategoryProduct(ProductCategory productCategory)
            => productCategories.Add(productCategory);
    }
}