using Krafted.Infrastructure.Connections;
using Krafted.Infrastructure.Connections.SqlServer;
using Krafted.Infrastructure.IntegrationTest.Migration;
using Krafted.Infrastructure.Sql;
using Krafted.Infrastructure.Sql.Bultin;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Krafted.Infrastructure.IntegrationTest
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