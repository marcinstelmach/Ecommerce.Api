using Autofac;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Implementation.Repositories;

namespace Streetwood.Core.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ShipmentRepository>().As<IShipmentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductCategoryRepository>().As<IProductCategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRespository>().As<IProductRepository>().InstancePerLifetimeScope();
        }
    }
}
