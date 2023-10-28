using Autofac;

namespace ManagementSystem.Infrastructure.Modules;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(Application.Exceptions.ApplicationException).Assembly)
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}
