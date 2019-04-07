using Krafted.Infrastructure.Connections;
using Krafted.Infrastructure.Connections.SqlServer;
using Krafted.Infrastructure.Repositories.Dapper;
using Krafted.Infrastructure.Transactions;
using Krafted.IntegrationTest.FooBar.Application;
using Krafted.IntegrationTest.FooBar.Domain;
using Krafted.IntegrationTest.Migration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Domain;
using SharedKernel.Transactions;

namespace Krafted.IntegrationTest
{
    public class Startup : Api.Startup
    {
        public Startup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddScoped<IConnectionProvider, SqlServerConnectionProvider>(
                _ => new SqlServerConnectionProvider(Configuration.GetConnectionString("StandardConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepositoryAsync<Foo>, RepositoryAsync<Foo>>();
            services.AddScoped<FooApplicationService>();
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            base.Configure(app, env);
            app.UseMigration(Configuration.GetConnectionString("StandardConnection"));
        }
    }
}