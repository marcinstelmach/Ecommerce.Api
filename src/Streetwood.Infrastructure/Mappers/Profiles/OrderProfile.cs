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
                .ForMember(dest => dest.ProductOrderCharms, opt => opt.MapFrom(src => src.ProductOrderCharms));

            CreateMap<ProductOrderCharm, ProductOrderCharmDto>();

            CreateMap<Order, OrdersListDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
        }
    }
}