using Autofac;
using Streetwood.Infrastructure.Factories.Abstract;
using Streetwood.Infrastructure.Factories.Implementation;

namespace Streetwood.Infrastructure.Modules
{
    public class FactoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AzureBlobStorageFactory>().As<IAzureStorageFactory>().InstancePerLifetimeScope();
        }
    }
}