using System;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Core.Domain.Models
{
    public class Discount : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsPercent { get; set; }
        public decimal Value { get; set; }
        public DiscountStatus Status { get; set; }
        public DiscountType Type { get; set; }
        public string Code { get; set; }
        public DateTime? AvaibleFrom { get; set; }
        public DateTime? AvaibleTo { get; set; }
    }
}