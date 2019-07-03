using System.Diagnostics.CodeAnalysis;
using Krafted.Infrastructure.Connections;
using Krafted.Infrastructure.Connections.SqlServer;
using Krafted.Infrastructure.Repositories.Dapper;
using Krafted.Infrastructure.Sql;
using Krafted.Infrastructure.Sql.Bultin;
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
    [ExcludeFromCodeCoverage]
    public class ApiStartup : Api.Startup
    {
        public ApiStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddScoped<IConnectionProvider, SqlServerConnectionProvider>(
                _ => new SqlServerConnectionProvider(ConfigurationHelper.GetConnectionString()));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISqlBuilderFactory, BultinSqlBuilderFactory>();
            services.AddScoped<IRepositoryAsync<Foo>, RepositoryAsync<Foo>>();
            services.AddScoped<FooApplicationService>();
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            base.Configure(app, env);
            app.UseMigration(ConfigurationHelper.GetConnectionString());
        }
    }
}