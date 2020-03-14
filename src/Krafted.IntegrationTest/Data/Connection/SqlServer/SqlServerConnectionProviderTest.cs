using System;
using System.Data.SqlClient;
using Krafted.Data.SqlServer.Connection;
using Xunit;
using Assert = Krafted.Test.XUnit.AssertExtension;

namespace Krafted.IntegrationTest.Data.Connection.SqlServer
{
    [Trait(nameof(IntegrationTest), nameof(Data))]
    public class SqlServerConnectionProviderTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void NewInstance_NotFilledConnectionString_ThrowsException(string connectionString)
            => Assert.Throws<ArgumentException>(() => new SqlServerConnectionProvider(connectionString));

        [Theory]
        [InlineData("Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;")]
        [InlineData("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;")]
        public void NewInstance_FilledConnectionString_DoesNotThrowsException(string connectionString)
            => Assert.DoesNotThrows(() => new SqlServerConnectionProvider(connectionString));

        [Fact]
        public void Create_Call_SqlConnectionCreated()
        {
            var provider = new SqlServerConnectionProvider("Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;");
            var connection = provider.Create();

            Assert.NotNull(connection);
            Assert.IsType<SqlConnection>(connection);
        }
    }
}