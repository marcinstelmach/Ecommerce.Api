using System;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class ProductOrderCharm : Entity
    {
        public decimal CurrentPrice { get; protected set; }

        public virtual Charm Charm { get; protected set; }

        public int Sequence { get; protected set; }

        public virtual ProductOrder ProductOrder { get; protected set; }

        public ProductOrderCharm(Charm charm, int sequence)
        {
            Id = Guid.NewGuid();
            CurrentPrice = charm.Price;
            AddCharm(charm);
            Sequence = sequence;
        }

        protected ProductOrderCharm()
        {
        }

        public void AddCharm(Charm charm)
            => Charm = charm;
    }
}