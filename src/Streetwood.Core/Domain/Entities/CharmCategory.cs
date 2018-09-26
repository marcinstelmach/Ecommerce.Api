using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class CharmCategory : Entity
    {
        private List<Charm> charms = new List<Charm>();

        public string Name { get; protected set; }

        public virtual IReadOnlyCollection<Charm> Charms => charms;

        public CharmCategory(string name)
        {
            Id = Guid.NewGuid();
            SetName(name);
        }

        protected CharmCategory()
        {
        }

        public void SetName(string name)
            => Name = name;

        public void AddCharm(Charm charm)
            => charms.Add(charm);
    }
}