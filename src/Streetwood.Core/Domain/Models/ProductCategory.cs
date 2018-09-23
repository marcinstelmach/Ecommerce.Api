using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Models
{
    public class ProductCategory : Entity
    {
        public string Name { get; set; }
        public bool IsPremium { get; set; }
        public int? ParentId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}