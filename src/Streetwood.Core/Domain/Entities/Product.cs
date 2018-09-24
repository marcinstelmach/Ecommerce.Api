using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Core.Domain.Entities
{
    public class Product : Entity
    {
        public new int Id { get; protected set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public ProductStatus Status { get; set; }

        public string Description { get; set; }

        public bool HasCharms { get; set; }

        public string Colors { get; set; }

        public string Sizes { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}