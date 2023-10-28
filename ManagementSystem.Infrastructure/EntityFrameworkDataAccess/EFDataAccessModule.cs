using Autofac;
using ManagementSystem.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess;

public class EFDataAccessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();

        builder.RegisterType<Context>()
            .WithParameter(new TypedParameter(typeof(DbContextOptions), optionsBuilder.Options))
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
            .Where(type => type.Namespace!.Contains("EntityFrameworkDataAccess"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}
