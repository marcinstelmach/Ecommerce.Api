using System;

namespace Streetwood.Infrastructure.Dto
{
    public class ProductCategoryDiscountWithDataDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsUse { get; set; }

        public ProductCategoryDiscountWithDataDto(Guid id, string name, bool isUse)
        {
            Id = id;
            Name = name;
            IsUse = isUse;
        }
    }
}
