using System.Diagnostics.CodeAnalysis;
using Krafted.Infrastructure.Connections;
using Krafted.Infrastructure.Connections.SqlServer;
using Krafted.Infrastructure.Sql;
using Krafted.Infrastructure.Sql.Bultin;
using Krafted.IntegrationTest.Migration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Krafted.IntegrationTest
{
    /// <summary>
    /// Represents the initialization class used for integration testing from the Repositories.
    /// </summary>
    /// <seealso cref="Krafted.Api.Startup" />
    [ExcludeFromCodeCoverage]
    public class InfrastructureStartup : Api.Startup
    {
        public InfrastructureStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddScoped<IConnectionProvider, SqlServerConnectionProvider>(
                _ => new SqlServerConnectionProvider(ConfigurationHelper.GetConnectionString()));

            services.AddScoped<ISqlBuilderFactory, BultinSqlBuilderFactory>();
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            base.Configure(app, env);
            app.UseMigration(ConfigurationHelper.GetConnectionString("InfrastructureConnection"));
        }
    }
}