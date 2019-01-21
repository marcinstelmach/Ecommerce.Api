using System.Linq;
using AutoMapper;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Mappers.Profiles
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
            : base("ProductCategories")
        {
            CreateMap<ProductCategory, ProductCategoryDto>()
                .ForMember(dest => dest.ProductCategoryDiscount,
                    opt => opt.MapFrom(src =>
                        src.DiscountCategories.FirstOrDefault(s => s.ProductCategoryDiscount.IsActive).ProductCategoryDiscount));
        }
    }
}
