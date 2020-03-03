using System.Data;
using Krafted.Data.Sql.Bultin;
using NSubstitute;
using Xunit;

namespace Krafted.IntegrationTest.Data.Sql.Bultin
{
    [Trait(nameof(IntegrationTest), nameof(Krafted))]
    public class BultinSqlBuilderFactoryTest
    {
        private readonly IDbConnection _connection;

        public BultinSqlBuilderFactoryTest() => _connection = Substitute.For<IDbConnection>();

        [Fact]
        public void NewSqlBuilder_EntityDummy_SqlBuilder()
        {
            var factory = new BultinSqlBuilderFactory();
            var builder = factory.NewSqlBuilder<EntityDummy>(_connection);

            Assert.NotNull(builder);
        }
    }
}