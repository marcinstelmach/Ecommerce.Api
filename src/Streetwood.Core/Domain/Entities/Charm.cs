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

        public string ImagePath { get; protected set; }

        public decimal Price { get; protected set; }

        public ItemStatus Status { get; protected set; }

        public virtual CharmCategory CharmCategory { get; protected set; }

        public virtual IReadOnlyCollection<ProductOrderCharm> ProductOrderCharms { get; }

        public Charm(string name, string nameEng, string imagePath, decimal price)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetNameEng(nameEng);
            SetUrl(imagePath);
            Price = price;
            SetStatus(ItemStatus.Available);
        }

        protected Charm()
        {
        }

        public void SetName(string name)
            => Name = name;

        public void SetNameEng(string name)
            => NameEng = name;

        public void SetStatus(ItemStatus status)
            => Status = status;

        public void SetUrl(string path)
            => ImagePath = path;
    }
}