using System.Data;
using Krafted.Infrastructure.Sql.Bultin;
using Krafted.UnitTest.Infrastructure.Repositories.Dapper;
using NSubstitute;
using Xunit;

namespace Krafted.UnitTest.Infrastructure.Sql.Bultin
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class BultinSqlBuilderFactoryTest
    {
        private readonly IDbConnection _connection;

        public BultinSqlBuilderFactoryTest() => _connection = Substitute.For<IDbConnection>();

        [Fact]
        public void NewSqlBuilder_Foo_SqlBuilderShouldBeCreated()
        {
            var factory = new BultinSqlBuilderFactory();
            factory.NewSqlBuilder<Foo>(_connection);

            Assert.NotNull(factory);
        }
    }
}