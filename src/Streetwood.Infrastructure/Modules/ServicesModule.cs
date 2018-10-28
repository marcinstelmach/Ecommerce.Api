using Autofac;
using Streetwood.Infrastructure.Services.Abstract.Commands;
using Streetwood.Infrastructure.Services.Abstract.Commands.Address;
using Streetwood.Infrastructure.Services.Abstract.Queries;
using Streetwood.Infrastructure.Services.Implementations.Commands;
using Streetwood.Infrastructure.Services.Implementations.Queries;

namespace Streetwood.Infrastructure.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserCommandService>().As<IUserCommandService>().InstancePerLifetimeScope();
            builder.RegisterType<UserQueryService>().As<IUserQueryService>().InstancePerLifetimeScope();

            builder.RegisterType<AddressCommandService>().As<IAddressCommandService>().InstancePerLifetimeScope();

            builder.RegisterType<ShipmentCommandService>().As<IShipmentCommandService>().InstancePerLifetimeScope();
            builder.RegisterType<ShipmentQueryService>().As<IShipmentQueryService>().InstancePerLifetimeScope();

            builder.RegisterType<ProductCategoryCommandService>().As<IProductCategoryCommandService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductCategoryQueryService>().As<IProductCategoryQueryService>().InstancePerLifetimeScope();

            builder.RegisterType<ProductCommandService>().As<IProductCommandService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductQueryService>().As<IProductQueryService>().InstancePerLifetimeScope();

            builder.RegisterType<CharmCategoryCommandService>().As<ICharmCategoryCommandService>().InstancePerLifetimeScope();
            builder.RegisterType<CharmCategoryQueryService>().As<ICharmCategoryQueryService>().InstancePerLifetimeScope();

            builder.RegisterType<CharmCommandService>().As<ICharmCommandService>().InstancePerLifetimeScope();
            builder.RegisterType<CharmQueryService>().As<ICharmQueryService>().InstancePerLifetimeScope();

            builder.RegisterType<ImageCommandService>().As<IImageCommandService>().InstancePerLifetimeScope();

            builder.RegisterType<ProductCategoryDiscountCommandService>().As<IProductCategoryDiscountCommandService>().InstancePerLifetimeScope();
        }
    }
}
