using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class OrderDiscount : DiscountEntity
    {
        private List<Order> orders = new List<Order>();

        public virtual IReadOnlyCollection<Order> Orders => orders;

        public OrderDiscount(string name, string nameEng, string description, string descriptionEng, int percentValue, bool isActive, DateTime avaibleFrom, DateTime avaibleTo)
            : base(name, nameEng, description, descriptionEng, percentValue, isActive, avaibleFrom, avaibleTo)
        {
        }

        protected OrderDiscount()
        {
        }
    }
}