using Streetwood.Core.Domain.Enums;

namespace Streetwood.Infrastructure.Dto
{
    public class CharmDto
    {
        public string Name { get; set; }

        public string NameEng { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public CharmStatus Status { get; set; }
    }
}
