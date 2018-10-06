using AutoMapper;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Mappers.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
            : base("Products")
        {
            CreateMap<Product, ProductListDto>();
        }
    }
}
