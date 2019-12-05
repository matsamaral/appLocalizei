
using Autofac;
using Autofac.Core;
using Localizei.Domain.Repositories;

namespace Brinks.Compusafe.User.API.AutofacModules
{
    public class InfraModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           
            builder
                .RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<LocatorRepository>()
                .As<ILocatorRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<RecogninRepository>()
                .As<IRecogninRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
