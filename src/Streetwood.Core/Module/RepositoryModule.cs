using Autofac;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Implementation.Repositories;

namespace Streetwood.Core.Module
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
        }
    }
}
