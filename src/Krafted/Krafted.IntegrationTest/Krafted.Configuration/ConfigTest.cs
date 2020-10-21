using System;
using Krafted.Configuration;
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
        public void InstanceHostEnvironment_GetConnectionString_ConnectionString(string environmentName, string expectedConnectionString)
        {
            var configuration = Config.Instance(new HostEnvironment(environmentName));
            var connectionString = configuration.GetConnectionString("StandardConnection");

            Assert.Equal(expectedConnectionString, connectionString);
        }

        [Theory]
        [InlineData("Development", "Development connection string")]
        [InlineData("Staging", "Staging connection string")]
        [InlineData("Production", "Production connection string")]
        public void InstanceEnvironmentVariable_GetConnectionString_ConnectionString(string environmentName, string expectedConnectionString)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", environmentName);

            var configuration = Config.Instance();
            var connectionString = configuration.GetConnectionString("StandardConnection");

            Assert.Equal(expectedConnectionString, connectionString);
        }
    }
}
