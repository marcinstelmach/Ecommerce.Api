using System;
using MediatR;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Infrastructure.Commands.Models.Shipment
{
    public class UpdateShipmentCommandModel : IRequest
    {
        public Guid Id { get; private set; }

        public string Name { get; set; }

        public string NameEng { get; set; }

        public string Description { get; set; }

        public string DescriptionEng { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public ShipmentType Type { get; set; }

        public UpdateShipmentCommandModel SetId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
