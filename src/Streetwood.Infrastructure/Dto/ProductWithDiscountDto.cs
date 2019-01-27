namespace Streetwood.Infrastructure.Dto
{
    public class ProductWithDiscountDto : ProductDto
    {
        public ProductCategoryDiscountDto Discount { get; set; }
    }
}
