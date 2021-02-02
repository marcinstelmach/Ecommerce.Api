using System.Linq;
using AutoMapper;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Dto.Products;

namespace Streetwood.Infrastructure.Mappers.Profiles
{

    public class ProductProfile : Profile
    {
        public ProductProfile()
            : base("Products")
        {
            CreateMap<Product, ProductListDto>()
                .ForMember(x => x.ImagePath, options => options.MapFrom(y => y.Images.FirstOrDefault() != null ? y.Images.FirstOrDefault().ImageUrl : null));
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductCategoryId, opt => opt.MapFrom(src => src.ProductCategory.Id));
            CreateMap<Product, ProductWithDiscountDto>();

            CreateMap<Image, ImageDto>()
                .ForMember(dest => dest.Name, opt => opt.ResolveUsing<ImageResolver>());

            CreateMap<ProductColor, ProductColorDto>();
        }
    }
}
