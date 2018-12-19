using System.Collections.Generic;

namespace Streetwood.Infrastructure.Dto
{
    public class ProductWithCharmsOrderDto
    {
        public int ProductId { get; set; }

        public IList<CharmOrderDto> Charms { get; set; }
    }
}