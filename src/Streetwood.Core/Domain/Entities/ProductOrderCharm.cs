using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class ProductOrderCharm : Entity
    {
        public decimal CurrentPrice { get; protected set; }

        public virtual Charm Charm { get; protected set; }

        public virtual ProductOrder ProductOrder { get; protected set; }

        public ProductOrderCharm(Charm charm)
        {
            CurrentPrice = charm.Price;
            AddCharm(charm);
        }

        protected ProductOrderCharm()
        {
        }

        public void AddCharm(Charm charm)
            => Charm = charm;
    }
}