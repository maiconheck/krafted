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
            var connection = (SqlConnection)Factory.New<SqlServerConnectionFactory>();
            AssertConnection(connection, string.Empty);

            var connection1 = (SqlConnection)Factory.New<SqlServerConnectionFactory, string>("A");
            AssertConnection(connection1, "A");

            var connection2 = (SqlConnection)Factory.New<SqlServerConnectionFactory, string, string>("A", "B");
            AssertConnection(connection2, "AB");
        }

        [Fact]
        public void New_OracleConnectionFactory_OracleConnection()
        {
            var connection = Factory.New<OracleConnectionFactory>();
            Assert.NotNull(connection);
            Assert.IsType<OracleConnection>(connection);
        }

        private static void AssertConnection(SqlConnection connection, string expected)
        {
            Assert.NotNull(connection);
            Assert.IsType<SqlConnection>(connection);
            Assert.Equal(expected, connection.ConnectionString);
        }
    }
}