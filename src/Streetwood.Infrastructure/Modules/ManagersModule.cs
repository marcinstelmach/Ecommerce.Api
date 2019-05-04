using Autofac;
using Streetwood.Core.Managers;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Managers.Implementations;

namespace Streetwood.Infrastructure.Modules
{
    public class ManagersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StringGenerator>().As<IStringGenerator>().InstancePerLifetimeScope();
            builder.RegisterType<Encrypter>().As<IEncrypter>().InstancePerLifetimeScope();
            builder.RegisterType<TokenManager>().As<ITokenManager>().InstancePerLifetimeScope();
            builder.RegisterType<PathManager>().As<IPathManager>().InstancePerLifetimeScope();
            builder.RegisterType<FileManager>().As<IFileManager>().InstancePerLifetimeScope();
            builder.RegisterType<MemoryCache>().As<ICache>().SingleInstance();
            builder.RegisterType<EmailTemplatesManager>().As<IEmailTemplatesManager>().InstancePerLifetimeScope();
            builder.RegisterType<MailKitManager>().As<IEmailManager>().InstancePerLifetimeScope();
            builder.RegisterType<AzureStorageQueueManager>().As<IQueueManager>().SingleInstance();
        }
    }
}
