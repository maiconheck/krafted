using Krafted.Configuration;
using Xunit;

namespace Krafted.IntegrationTest.Krafted
{
    [Trait(nameof(IntegrationTest), nameof(Krafted))]
    public class ConfigurationHelperTest
    {
        [Fact]
        public void GetConnectionString_Name_ConnectionString()
        {
            string connectionString = Config.Instance().GetConnectionString();
            Assert.Equal("Server=(local)\\SqlExpress;Database=Krafted;Trusted_Connection=True", connectionString);

            connectionString = Config.Instance().GetConnectionString("NotExistentConnectionString");
            Assert.Null(connectionString);
        }
    }
}