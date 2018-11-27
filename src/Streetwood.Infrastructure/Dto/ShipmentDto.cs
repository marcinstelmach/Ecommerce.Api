using System;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Infrastructure.Dto
{
    public class ShipmentDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NameEng { get; set; }

        public string Description { get; set; }

        public string DescriptionEng { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public ShipmentType Type { get; set; }
    }
}
