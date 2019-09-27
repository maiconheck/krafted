using System;
using System.Data;
using System.Data.SqlClient;
using Krafted.Infrastructure.Connections.SqlServer;
using Krafted.Test;
using Xunit;

namespace Krafted.UnitTest.Infrastructure.Connections.SqlServer
{
    [Trait(nameof(UnitTest), nameof(Infrastructure))]
    public class SqlServerConnectionProviderTest : XUnitTestBase
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void NewInstance_NotFilledConnectionString_ExceptionShouldBeThrow(string connectionString)
            => Throws(() => new SqlServerConnectionProvider(connectionString));

        [Theory]
        [InlineData("Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;")]
        [InlineData("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;")]
        public void NewInstance_FilledConnectionString_ExceptionShouldNotBeThrow(string connectionString)
            => DoesNotThrows(() => new SqlServerConnectionProvider(connectionString));

        [Fact]
        public void Create_Call_SqlConnectionShouldBeCreated()
        {
            var provider = new SqlServerConnectionProvider("Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;");
            var connection = provider.Create();

            Assert.NotNull(connection);
            Assert.IsType<SqlConnection>(connection);
        }
    }
}