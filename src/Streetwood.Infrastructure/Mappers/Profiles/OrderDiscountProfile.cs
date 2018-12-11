using AutoMapper;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Mappers.Profiles
{
    public class OrderDiscountProfile : Profile
    {
        public OrderDiscountProfile()
            : base("OrderDiscount")
        {
            CreateMap<OrderDiscount, OrderDiscountDto>();
        }
    }
}
