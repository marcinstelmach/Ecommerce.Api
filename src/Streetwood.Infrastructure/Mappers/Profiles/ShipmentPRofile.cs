using AutoMapper;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Mappers.Profiles
{
    public class ShipmentProfile : Profile
    {
        public ShipmentProfile()
            : base("Shipments")
        {
            CreateMap<Shipment, ShipmentDto>();
        }
    }
}
