using System.Diagnostics.CodeAnalysis;
using Krafted.Data.Connection;
using Krafted.Data.Sql;
using Krafted.Data.Sql.Bultin;
using Krafted.Data.SqlServer.Connection;
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
                _ => new SqlServerConnectionProvider(Config.Instance().GetConnectionString()));

            services.AddScoped<ISqlBuilderFactory, BultinSqlBuilderFactory>();
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            base.Configure(app, env);
            app.UseMigration(Config.Instance().GetConnectionString());
        }
    }
}