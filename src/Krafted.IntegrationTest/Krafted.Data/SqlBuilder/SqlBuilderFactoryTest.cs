using Krafted.Configuration;
using Krafted.Data.Connection;
using Krafted.Data.SqlBuilder;
using Krafted.Data.SqlServer.Connection;
using Krafted.Data.SqlServer.SqlBuilder;
using Xunit;

namespace Krafted.IntegrationTest.Krafted.Data.SqlBuilder
{
    [Trait(nameof(IntegrationTest), nameof(Krafted))]
    public class SqlBuilderFactoryTest
    {
        [Fact]
        public void NewSqlBuilder_EntityDummy_SqlBuilder()
        {
            var connectionString = Config.Instance().GetConnectionString();
            var connection = ConnectionFactory.NewConnection<SqlServerConnectionFactory>(connectionString);

            var builder = SqlBuilderFactory.NewSqlBuilder<EntityDummy, BultinSqlBuilderFactory>(connection);
            Assert.NotNull(builder);
        }
    }
}