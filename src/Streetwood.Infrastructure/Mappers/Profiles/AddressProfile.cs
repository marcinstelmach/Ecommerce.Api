using AutoMapper;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Mappers.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
            : base("Address")
        {
            CreateMap<Address, AddressDto>();
        }
    }
}
