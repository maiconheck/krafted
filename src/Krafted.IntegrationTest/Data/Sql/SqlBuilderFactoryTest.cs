using Krafted.Data.Connection;
using Krafted.Data.Connection.SqlServer;
using Krafted.Data.Sql;
using Krafted.Data.Sql.Bultin;
using Krafted.IntegrationTest.Data.Sql.Bultin;
using Xunit;

namespace Krafted.IntegrationTest.Data.Sql
{
    [Trait(nameof(IntegrationTest), nameof(Krafted))]
    public class SqlBuilderFactoryTest
    {
        [Fact]
        public void NewSqlBuilder_EntityDummy_SqlBuilder()
        {
            var connectionString = Config.Instance().GetConnectionString("SqlServerConnection");
            var connection = ConnectionFactory.NewConnection<SqlServerConnectionFactory>(connectionString);

            var builder = SqlBuilderFactory.NewSqlBuilder<EntityDummy, BultinSqlBuilderFactory>(connection);
            Assert.NotNull(builder);
        }
    }
}