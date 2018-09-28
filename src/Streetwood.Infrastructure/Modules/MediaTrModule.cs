using Autofac;
using MediatR;

namespace Streetwood.Infrastructure.Modules
{
    public class MediaTrModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.Register<ServiceFactory>(ctx =>
            {
                var context = ctx.Resolve<IComponentContext>();
                return t => context.Resolve(t);
            }).InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(GetType().Assembly)
                .Where(s => s.Name.EndsWith("Handler"))
                .AsImplementedInterfaces();
        }
    }
}
