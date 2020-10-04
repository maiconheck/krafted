using Krafted.DesignPatterns.Factories;
using Krafted.UnitTest.Krafted.DesignPatterns.Factories.Oracle;
using Krafted.UnitTest.Krafted.DesignPatterns.Factories.SqlServer;
using Xunit;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Factories
{
    [Trait(nameof(UnitTest), nameof(DesignPatterns))]
    public class FactoryTest
    {
        [Fact]
        public void New_SqlServerConnectionFactoryAndParameters_SqlServerConnection()
        {
            var connection = (SqlConnection)Factory.New<SqlServerConnectionFactory>();
            Assert.NotNull(connection);
            Assert.IsType<SqlConnection>(connection);

            var connection1 = (SqlConnection)Factory.New<SqlServerConnectionFactory, string>("A");
            AssertSqlConnectionConnection(connection1, "A");

            var connection2 = (SqlConnection)Factory.New<SqlServerConnectionFactory, string, string>("A", "B");
            AssertSqlConnectionConnection(connection2, "A B");

            var connection3 = (SqlConnection)Factory.New<SqlServerConnectionFactory, string, string, string>("A", "B", "C");
            AssertSqlConnectionConnection(connection3, "A B C");

            var connection4 = (SqlConnection)Factory.New<SqlServerConnectionFactory, string, string, string, string>("A", "B", "C", "D");
            AssertSqlConnectionConnection(connection4, "A B C D");

            var connection5 = (SqlConnection)Factory.New<SqlServerConnectionFactory, string, string, string, string, string>("A", "B", "C", "D", "E");
            AssertSqlConnectionConnection(connection5, "A B C D E");

            void AssertSqlConnectionConnection(SqlConnection conn, string expected)
            {
                Assert.NotNull(conn);
                Assert.IsType<SqlConnection>(conn);
                Assert.Equal(expected, conn.ConnectionString);
            }
        }

        [Fact]
        public void New_OracleConnectionFactoryAndParameters_OracleConnection()
        {
            var connection = Factory.New<OracleConnectionFactory>();
            Assert.NotNull(connection);
            Assert.IsType<OracleConnection>(connection);

            var connection1 = (OracleConnection)Factory.New<OracleConnectionFactory, string>("A");
            AssertOracleConnection(connection1, "A");

            var connection2 = (OracleConnection)Factory.New<OracleConnectionFactory, string, string>("A", "B");
            AssertOracleConnection(connection2, "A B");

            var connection3 = (OracleConnection)Factory.New<OracleConnectionFactory, string, string, string>("A", "B", "C");
            AssertOracleConnection(connection3, "A B C");

            var connection4 = (OracleConnection)Factory.New<OracleConnectionFactory, string, string, string, string>("A", "B", "C", "D");
            AssertOracleConnection(connection4, "A B C D");

            var connection5 = (OracleConnection)Factory.New<OracleConnectionFactory, string, string, string, string, string>("A", "B", "C", "D", "E");
            AssertOracleConnection(connection5, "A B C D E");

            void AssertOracleConnection(OracleConnection conn, string expected)
            {
                Assert.NotNull(conn);
                Assert.IsType<OracleConnection>(conn);
                Assert.Equal(expected, conn.ConnectionString);
            }
        }
    }
}