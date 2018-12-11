using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class OrderDiscount : DiscountEntity
    {
        private List<Order> orders = new List<Order>();

        public string Code { get; protected set; }

        public virtual IReadOnlyCollection<Order> Orders => orders;

        public OrderDiscount(string name, string nameEng, string description, string descriptionEng, int percentValue, bool isActive, DateTime availableFrom, DateTime avaibleTo, string code)
            : base(name, nameEng, description, descriptionEng, percentValue, isActive, availableFrom, avaibleTo)
        {
            SetCode(code);
        }

        protected OrderDiscount()
        {
        }

        public void SetCode(string code)
            => Code = code;
    }
}