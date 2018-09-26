using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class ProductDiscount : DiscountEntity
    {
        private List<Product> products = new List<Product>();

        public virtual IReadOnlyCollection<Product> Products => products;

        public ProductDiscount(string name, string nameEng, string description, string descriptionEng, decimal percentValue, bool isActive, DateTime avaibleFrom, DateTime avaibleTo) 
            : base(name, nameEng, description, descriptionEng, percentValue, isActive, avaibleFrom, avaibleTo)
        {
        }

        protected ProductDiscount()
        {
        }

        public void AddProducts(Product product)
            => products.Add(product);
    }
}