using Streetwood.Core.Domain.Enums;

namespace Streetwood.Infrastructure.Dto
{
    public class ProductListDto
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
    }
}
