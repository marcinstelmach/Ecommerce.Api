using System;

namespace Streetwood.Infrastructure.Dto
{
    public class ProductsCategoriesForDiscountDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Selected { get; set; }

        public ProductsCategoriesForDiscountDto(Guid id, string name, bool selected)
        {
            Id = id;
            Name = name;
            Selected = selected;
        }
    }
}
