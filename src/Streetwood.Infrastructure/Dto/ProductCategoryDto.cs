using System;
using System.Collections.Generic;

namespace Streetwood.Infrastructure.Dto
{
    public class ProductCategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NameEng { get; set; }

        public bool HasOneProduct { get; set; }

        public IEnumerable<ProductCategoryDto> ProductCategories { get; set; }

        public ProductCategoryDiscountDto ProductCategoryDiscount { get; set; }
    }
}
