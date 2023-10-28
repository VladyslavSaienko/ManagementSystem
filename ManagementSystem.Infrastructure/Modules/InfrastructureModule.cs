using Autofac;
using Autofac.Core;
using ManagementSystem.Infrastructure.EntityFrameworkDataAccess;
using ManagementSystem.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Infrastructure.Modules
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(x =>x.Namespace!.Contains("Queries"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<Context>().As<DbContext>();
        }
    }
}
