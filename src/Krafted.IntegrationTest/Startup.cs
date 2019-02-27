using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Domain;
using Krafted.IntegrationTest.FooBar.Application;
using Krafted.IntegrationTest.FooBar.Domain;
using Krafted.IntegrationTest.FooBar.Infrastructure;
using Krafted.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Krafted.IntegrationTest.Migration;

namespace Krafted.IntegrationTest
{
    public class Startup : Startup<Startup>
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepositoryAsync<Foo>, FooRepository>();
            services.AddScoped<FooApplicationService>();
            base.ConfigureServices(services);
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            base.Configure(app, env);
            app.UseMigration("Server=(localdb)\\MSSQLLocalDB;Database=Krafted;Integrated Security=true;MultipleActiveResultSets=true");
        }
    }
}