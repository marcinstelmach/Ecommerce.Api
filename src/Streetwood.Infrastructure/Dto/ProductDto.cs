using System.Collections.Generic;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Infrastructure.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameEng { get; set; }

        public decimal Price { get; set; }

        public ProductStatus Status { get; set; }

        public string Description { get; set; }

        public string DescriptionEng { get; set; }

        public bool AcceptCharms { get; set; }

        public string Sizes { get; set; }

        public IList<ImageDto> Images { get; set; }
    }
}
