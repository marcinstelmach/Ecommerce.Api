using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Core.Domain.Entities
{
    public class Charm : Entity
    {
        public string Name { get; protected set; }

        public string NameEng { get; protected set; }

        public string ImageUrl { get; protected set; }

        public decimal Price { get; protected set; }

        public CharmStatus Status { get; protected set; }

        public virtual CharmCategory CharmCategory { get; protected set; }

        public virtual IReadOnlyCollection<ProductOrderCharm> ProductOrderCharms { get; }

        public Charm(string name, string nameEng, string imageUrl, decimal price)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetNameEng(nameEng);
            SetUrl(imageUrl);
            Price = price;
            SetStatus(CharmStatus.Avaible);
        }

        protected Charm()
        {
        }

        public void SetName(string name)
            => Name = name;

        public void SetNameEng(string name)
            => NameEng = name;

        public void SetStatus(CharmStatus status)
            => Status = status;

        public void SetUrl(string url)
            => ImageUrl = url;
    }
}