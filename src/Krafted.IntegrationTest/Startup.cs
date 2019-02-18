using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Domain;
using Krafted.IntegrationTest.FooBar.Application;
using Krafted.IntegrationTest.FooBar.Domain;
using Krafted.IntegrationTest.FooBar.Infrastructure;
using Krafted.Api;

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

            // TODO: Carregar App_Data\Teste.mdf.
            // TODO: Flexibilizar a prop DbSettings.ConnectionStringMigration para poder construir a connection string manualmente.
            //var pathDB = Path.Combine(Directory.GetCurrentDirectory(), @"App_Data\Teste.mdf");
            //AppDomain.CurrentDomain.SetData("DataDirectory", pathDB);

            base.ConfigureServices(services);
            services.ConfigureMvcDefault();
        }
    }
}