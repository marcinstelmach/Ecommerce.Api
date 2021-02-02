using System;

namespace Streetwood.Infrastructure.Dto.Products
{
    public class AddProductDto
    {
        public string Name { get; set; }

        public string NameEng { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string DescriptionEng { get; set; }

        public bool AcceptCharms { get; set; }

        public int MaxCharmCount { get; set; }

        public string Sizes { get; set; }

        public Guid ProductCategoryId { get; set; }
    }
}