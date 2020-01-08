using System.Collections.Generic;
using System.Linq;

namespace Streetwood.Infrastructure.Dto
{
    public class ProductWithCharmsOrderDto
    {
        public int ProductId { get; set; }

        public int Amount { get; set; }

        public string Comment { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public bool HaveCharms => Charms.Any();

        public IList<CharmOrderDto> Charms { get; set; } = new List<CharmOrderDto>();
    }
}