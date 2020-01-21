using System;
using System.Collections.Generic;
using Streetwood.Infrastructure.Dto.Products;

namespace Streetwood.Infrastructure.Dto
{
    public class ProductOrderDto
    {
        public Guid Id { get; set; }

        public int Amount { get; set; }

        public decimal CurrentProductPrice { get; set; }

        public decimal FinalPrice { get; set; }

        public string Comment { get; set; }

        public decimal CharmsPrice { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public ProductCategoryDiscountDto ProductCategoryDiscount { get; set; }

        public ProductDto Product { get; set; }

        public IEnumerable<ProductOrderCharmDto> ProductOrderCharms { get; set; }
    }
}
