using AutoMapper;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto.User;

namespace Streetwood.Infrastructure.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
            : base("Users")
        {
            CreateMap<User, UserDto>();
        }
    }
}
