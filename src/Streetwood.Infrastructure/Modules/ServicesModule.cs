using Autofac;
using Streetwood.Infrastructure.Services.Abstract.Commands.User;
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
        }
    }
}
