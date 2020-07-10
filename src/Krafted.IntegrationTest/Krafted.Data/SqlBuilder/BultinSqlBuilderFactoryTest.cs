using System.Data;
using Krafted.Data.SqlServer.SqlBuilder;
using NSubstitute;
using Xunit;

namespace Krafted.IntegrationTest.Krafted.Data.SqlBuilder
{
    [Trait(nameof(IntegrationTest), nameof(Krafted))]
    public class BultinSqlBuilderFactoryTest
    {
        private readonly IDbConnection _connection;

        public BultinSqlBuilderFactoryTest() => _connection = Substitute.For<IDbConnection>();

        [Fact(Skip = "wip: database in continuous integration")]
        public void NewSqlBuilder_EntityDummy_SqlBuilder()
        {
            var factory = new BultinSqlBuilderFactory();
            var builder = factory.NewSqlBuilder<EntityDummy>(_connection);

            Assert.NotNull(builder);
        }
    }
}
