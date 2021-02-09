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
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.ClosedDateTime, opt => opt.MapFrom(src => src.ClosedDateTime ?? default));

            CreateMap<ProductOrder, ProductOrderDto>()
                .ForMember(dest => dest.ProductOrderCharms, opt => opt.MapFrom(src => src.ProductOrderCharms));

            CreateMap<ProductOrderCharm, ProductOrderCharmDto>();

            CreateMap<Order, OrderOverviewDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.OrderPayment.Status))
                .ForMember(dest => dest.ShipmentStatus, opt => opt.MapFrom(src => src.OrderShipment.Status));

            CreateMap<OrderShipment, OrderShipmentDto>();

            CreateMap<OrderPayment, OrderPaymentDto>();
        }
    }
}