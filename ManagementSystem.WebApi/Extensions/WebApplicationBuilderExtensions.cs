using Autofac;
using ManagementSystem.Infrastructure.EntityFrameworkDataAccess;
using ManagementSystem.Infrastructure.Modules;

namespace ManagementSystem.WebApi.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static IHostBuilder ConfigureAutofacContainer(this IHostBuilder builder)
    {
        builder.ConfigureContainer<ContainerBuilder>(
        builder => builder
                .RegisterModule(new ApplicationModule())
                .RegisterModule(new InfrastructureModule())
                .RegisterModule(new WebApiModule())
                .RegisterModule(new EFDataAccessModule()));

        return builder;
    }
}
