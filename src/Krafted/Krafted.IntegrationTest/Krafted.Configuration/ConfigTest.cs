using Krafted.Configuration;
using Krafted.UnitTest.Krafted.Configuration;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Krafted.IntegrationTest.Krafted.Configuration
{
    [Trait(nameof(IntegrationTest), nameof(Krafted))]
    public class ConfigTest
    {
        [Theory]
        [InlineData("Development", "Development connection string")]
        [InlineData("Staging", "Staging connection string")]
        [InlineData("Production", "Production connection string")]
        public void GetConnectionString_Name_ConnectionString(string environmentName, string expectedConnectionString)
        {
            var env = new HostEnvironmentStub(environmentName);
            var configuration = Config.Instance(env);
            var connectionString = configuration.GetConnectionString("StandardConnection");

            Assert.Equal(expectedConnectionString, connectionString);
        }
    }
}
