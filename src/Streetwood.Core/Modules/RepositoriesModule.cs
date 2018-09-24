using Autofac;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Implementation.Repositories;

namespace Streetwood.Core.Modules
{
    public class RepositoriesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
        }
    }
}
