using Autofac;
using Streetwood.Infrastructure.Services.Abstract.Commands.User;
using Streetwood.Infrastructure.Services.Implementations.Commands;

namespace Streetwood.Infrastructure.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserCommandService>().As<IUserCommandService>().InstancePerLifetimeScope();
        }
    }
}
