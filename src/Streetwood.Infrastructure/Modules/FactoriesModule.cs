using Autofac;
using Streetwood.Infrastructure.Factories.Abstract;
using Streetwood.Infrastructure.Factories.Implementation;

namespace Streetwood.Infrastructure.Modules
{
    using Streetwood.Infrastructure.Services.Abstract;
    using Streetwood.Infrastructure.Services.Implementations;

    public class FactoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AzureBlobStorageFactory>().As<IAzureStorageFactory>().InstancePerLifetimeScope();
            builder.RegisterType<OrderFactory>().As<IOrderFactory>().InstancePerLifetimeScope();
        }
    }
}