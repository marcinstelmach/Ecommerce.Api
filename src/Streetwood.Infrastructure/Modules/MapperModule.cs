using Autofac;
using AutoMapper;
using Streetwood.Infrastructure.Mappers;

namespace Streetwood.Infrastructure.Modules
{
    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).As<IMapper>().SingleInstance();
        }
    }
}
