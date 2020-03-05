using Krafted.DesignPatterns.Factories;
using Krafted.UnitTest.DesignPatterns.Factories.Oracle;
using Krafted.UnitTest.DesignPatterns.Factories.SqlServer;
using Xunit;

namespace Krafted.UnitTest.DesignPatterns.Factories
{
    [Trait(nameof(UnitTest), nameof(DesignPatterns))]
    public class FactoryTest
    {
        [Fact]
        public void New_SqlServerConnectionFactory_SqlServerConnection()
        {
            var connection = Factory.New<SqlServerConnectionFactory>();
            Assert.NotNull(connection);
            Assert.IsType<SqlConnection>(connection);
        }

        [Fact]
        public void New_OracleConnectionFactory_OracleConnection()
        {
            var connection = Factory.New<OracleConnectionFactory>();
            Assert.NotNull(connection);
            Assert.IsType<OracleConnection>(connection);
        }
    }
}
