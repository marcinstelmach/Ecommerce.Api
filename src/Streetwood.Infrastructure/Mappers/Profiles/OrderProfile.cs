using AutoMapper;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Mappers.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
            : base("Orders")
        {
            CreateMap<Order, OrderDto>();

            CreateMap<ProductOrder, ProductOrderDto>()
                .ForMember(dest => dest.ProductOrderCharm, opt => opt.MapFrom(src => src.ProductOrderCharms));

            CreateMap<ProductOrderCharm, ProductOrderCharmDto>();
        }
    }
}
