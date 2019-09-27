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
    /// Represents the initialization class used for integration testing from the REST API.
    /// </summary>
    /// <seealso cref="Api.Startup" />
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

            services.AddScoped<ISqlBuilderFactory, BultinSqlBuilderFactory>();
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            base.Configure(app, env);
            app.UseMigration(ConfigurationHelper.GetConnectionString());
        }
    }
}