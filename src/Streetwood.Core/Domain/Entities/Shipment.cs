using System;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Core.Domain.Entities
{
    public class Shipment : Entity
    {
        public string Name { get; protected set; }

        public string NameEng { get; protected set; }

        public string Description { get; protected set; }

        public string DescriptionEng { get; protected set; }

        public decimal Price { get; protected set; }

        public bool IsActive { get; protected set; }

        public ShipmentType Type { get; protected set; }

        public Shipment(string name, string nameEng, string description, string descriptionEng, decimal price, ShipmentType type)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetEngName(nameEng);
            SetDescription(description);
            SetDescriptionEng(descriptionEng);
            SetPrice(price);
            SetIsActive(true);
            SetType(type);
        }

        protected Shipment()
        {
        }

        public void SetName(string name)
            => Name = name;

        public void SetEngName(string name)
            => NameEng = name;

        public void SetDescription(string description)
            => Description = description;

        public void SetDescriptionEng(string description)
            => DescriptionEng = description;

        public void SetType(ShipmentType type)
            => Type = type;

        public void SetIsActive(bool isActive)
            => IsActive = isActive;

        public void SetPrice(decimal price)
            => Price = price;
    }
}