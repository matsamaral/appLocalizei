using Autofac;
using Localizei.Domain.Services;

namespace Brinks.Compusafe.User.API.AutofacModules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

          builder.RegisterType<UserService>()
              .As<IUserService>()
              .InstancePerLifetimeScope();

          builder.RegisterType<LocatorService>()
              .As<ILocatorService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<RecogninService>()
                .As<IRecogninService>()
                .InstancePerLifetimeScope();
        }
    }
}
