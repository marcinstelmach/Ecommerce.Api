using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class ProductOrderCharm : Entity
    {
        public int CurrentPrice { get; set; }

        public int OrderId { get; set; }

        public int CharmId { get; set; }

        public Charm Charm { get; set; }

        public ProductOrder ProductOrder { get; set; }
    }
}