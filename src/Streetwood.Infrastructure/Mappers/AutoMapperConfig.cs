using AutoMapper;
using Streetwood.Infrastructure.Mappers.Profiles;

namespace Streetwood.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
                cfg.AddProfile(new ShipmentProfile());
                cfg.AddProfile(new ProductCategoryProfile());
                cfg.AddProfile(new ProductProfile());
                cfg.AddProfile(new CharmCategoryProfile());
                cfg.AddProfile(new ProductCategoryDiscountProfile());
                cfg.AddProfile(new AddressProfile());
                cfg.AddProfile(new OrderDiscountProfile());
                cfg.AddProfile(new OrderProfile());
            })
            .CreateMapper();
        }
    }
}
