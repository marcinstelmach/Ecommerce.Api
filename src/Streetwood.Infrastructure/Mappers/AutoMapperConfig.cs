using AutoMapper;
using Streetwood.Infrastructure.Mappers.Profiles;

namespace Streetwood.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            })
            .CreateMapper();
        }
    }
}
