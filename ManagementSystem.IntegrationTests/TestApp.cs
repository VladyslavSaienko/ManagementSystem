using ManagementSystem.IntegrationTests.Fixtures;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystem.Infrastructure.EntityFrameworkDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ManagementSystem.IntegrationTests
{
    internal class TestApp : WebApplicationFactory<Program>
    {
        private IServiceScope _scope;
        private Guid _dbGuid;
        private bool _reuseScope = true;
        private Action<IServiceCollection> _customization;
        private Dictionary<string, string> _configurationOverrides;

        private TestApp(Action<IServiceCollection> customization, Dictionary<string, string> configurationOverrides)
        {
            ClientOptions.AllowAutoRedirect = false;
            ClientOptions.BaseAddress = new Uri("https://localhost");
            _customization = customization;
            _configurationOverrides = configurationOverrides;
            _scope = base.Services.CreateAsyncScope();
            _dbGuid = Guid.NewGuid();
        }

        public static TestApp CreateInstance()
        {
            var sut = new TestApp(_ => { }, new Dictionary<string, string>() { });
            return sut;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureAppConfiguration((builder, configurationBuilder) =>
            {
                configurationBuilder.AddInMemoryCollection(_configurationOverrides);
            });

            builder.ConfigureServices(services =>
            {
            });

            builder.ConfigureTestServices(services =>
            {
                // Remove the existing DbContext.
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<Context>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Use in memory DB instead.
                services.AddDbContext<Context>(config => config.UseInMemoryDatabase($"UsersDb{_dbGuid}")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));
                services.AddSingleton<StudentFixture>();

                services.BuildServiceProvider();
            });

            builder.ConfigureTestServices(_customization);
        }

        private IServiceScope RequestScope()
        {
            if (!_reuseScope)
            {
                _scope.Dispose();
                _scope = Services.CreateScope();
            }
            return _scope;
        }

        public StudentFixture StudentFixture
                => RequestScope().ServiceProvider.GetRequiredService<StudentFixture>();
    }
}
