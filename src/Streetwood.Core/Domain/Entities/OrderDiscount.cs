using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class OrderDiscount : DiscountEntity
    {
        private readonly List<Order> orders = new List<Order>();

        public string Code { get; protected set; }

        public virtual IReadOnlyCollection<Order> Orders => orders;

        public OrderDiscount(string name, string nameEng, string description, string descriptionEng, int percentValue, DateTime availableFrom, DateTime availableTo, string code)
            : base(name, nameEng, description, descriptionEng, percentValue, availableFrom, availableTo)
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