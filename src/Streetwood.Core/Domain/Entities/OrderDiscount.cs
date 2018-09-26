using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Core.Domain.Entities
{
    public class OrderDiscount : Entity
    {
        private List<Order> orders = new List<Order>();

        public string Name { get; protected set; }

        public string NameEng { get; protected set; }

        public string Description { get; protected set; }

        public string DescriptionEng { get; protected set; }

        public bool? IsPercent { get; protected set; }

        public decimal Value { get; protected set; }

        public DiscountType Type { get; protected set; }

        public string Code { get; protected set; }

        public DateTime? AvaibleFrom { get; protected set; }

        public DateTime? AvaibleTo { get; protected set; }

        public IReadOnlyCollection<Order> Orders => orders;

        public ProductDiscount(string name, string nameEng, string description, bool? isPercent, decimal value, DiscountStatus status, DiscountType type, string code, DateTime? avaibleFrom, DateTime? avaibleTo)
        {
            Name = name;
            NameEng = nameEng;
            Description = description;
            IsPercent = isPercent;
            Value = value;
            Status = status;
            Type = type;
            Code = code;
            AvaibleFrom = avaibleFrom;
            AvaibleTo = avaibleTo;
        }

        protected ProductDiscount()
        {
        }

    }
}