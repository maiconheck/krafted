using Xunit;

namespace Krafted.IntegrationTest
{
    [Trait(nameof(IntegrationTest), nameof(Krafted))]
    public class ConfigurationHelperTest
    {
        [Fact]
        public void GetConnectionString_Name_ConnectionString()
        {
            string connectionString = ConfigurationHelper.GetConnectionString();
            Assert.Equal("Server=(local)\\SqlExpress;Database=Krafted;Trusted_Connection=True", connectionString);

            connectionString = ConfigurationHelper.GetConnectionString("NotExistentConnectionString");
            Assert.Null(connectionString);
        }
    }
}
