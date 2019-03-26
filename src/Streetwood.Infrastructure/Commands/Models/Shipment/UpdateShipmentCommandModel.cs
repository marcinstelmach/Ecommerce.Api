using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Infrastructure.Commands.Models.Shipment
{
    public class UpdateShipmentCommandModel : IRequest
    {
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string NameEng { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string DescriptionEng { get; set; }

        [Required]
        [RegularExpression("^\\d{0,8}(\\.\\d{1,2})?$")]
        public decimal Price { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public ShipmentType Type { get; set; }

        public UpdateShipmentCommandModel SetId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
