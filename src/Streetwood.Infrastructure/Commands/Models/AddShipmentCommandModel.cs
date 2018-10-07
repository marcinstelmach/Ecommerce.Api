using MediatR;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Infrastructure.Commands.Models
{
    public class AddShipmentCommandModel : IRequest
    {
        public string Name { get; set; }

        public string NameEng { get; set; }

        public string Description { get; set; }

        public string DescriptionEng { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public ShipmentType Type { get; set; }
    }
}
