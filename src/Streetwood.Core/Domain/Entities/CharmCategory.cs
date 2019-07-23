using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Extensions;

namespace Streetwood.Core.Domain.Entities
{
    public class CharmCategory : Entity
    {
        private List<Charm> charms = new List<Charm>();

        public string Name { get; protected set; }

        public string NameEng { get; protected set; }

        public string UniqueName { get; set; }

        public ItemStatus Status { get; protected set; }

        public virtual List<Charm> Charms => charms;

        public CharmCategory(string name, string nameEng)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetEngName(nameEng);
            SetStatus(ItemStatus.Available);
            UniqueName = name.AppendRandom(5);
        }

        protected CharmCategory()
        {
        }

        public void SetName(string name)
            => Name = name;

        public void SetEngName(string name)
            => NameEng = name;

        public void SetStatus(ItemStatus status)
            => Status = status;

        public void AddCharm(Charm charm)
            => charms.Add(charm);

        public void AddCharms(IEnumerable<Charm> newCharms)
            => charms.AddRange(newCharms);
    }
}