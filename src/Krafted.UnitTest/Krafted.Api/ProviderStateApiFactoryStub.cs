using Krafted.Api;
using Microsoft.AspNetCore.Hosting;

namespace Krafted.UnitTest.Krafted.Api
{
    public class ProviderStateApiFactoryStub : ProviderStateApiFactory<Startup>
    {
        public new IWebHostBuilder CreateWebHostBuilder() => base.CreateWebHostBuilder();

        public new void ConfigureWebHost(IWebHostBuilder builder) => base.ConfigureWebHost(builder);
    }
}