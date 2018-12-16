using System.Linq;
using AutoMapper;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Mappers.Profiles
{
    public class ProductCategoryDiscountProfile : Profile
    {
        public ProductCategoryDiscountProfile()
            : base("ProductCategoryDiscount")
        {
            CreateMap<ProductCategoryDiscount, ProductCategoryDiscountDto>()
                .ForMember(dest => dest.CategoryIds, opt => opt.MapFrom(
                    src => src.DiscountCategories.Select(s => s.ProductCategory)));
        }
    }
}
