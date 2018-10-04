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
            CreateMap<ProductCategory, ProductCategoryDto>();
        }
    }
}
