using System.Collections.Generic;

namespace Streetwood.Infrastructure.Dto
{
    public class CharmCategoryDto
    {
        public string Name { get; set; }

        public IList<ProductDto> Products { get; set; }
    }
}
