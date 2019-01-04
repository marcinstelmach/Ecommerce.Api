using System.Linq;
using Autofac;
using Microsoft.EntityFrameworkCore.Internal;

namespace Streetwood.Infrastructure.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var services = ThisAssembly.GetTypes()
                .Where(s => s.IsClass)
                .Where(s => s.DisplayName().EndsWith("Service"))
                .Select(s => s.UnderlyingSystemType)
                .ToList();
            services.ForEach(s => builder.RegisterType(s).AsImplementedInterfaces().InstancePerLifetimeScope());
        }
    }
}
