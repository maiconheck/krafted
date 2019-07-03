using System;
using Krafted.Api;
using Krafted.Infrastructure.Connections.SqlServer;
using Krafted.Infrastructure.Sql;
using Krafted.Infrastructure.Sql.Bultin;
using Krafted.IntegrationTest.FooBar.Domain;
using Krafted.Test;
using Xunit;

namespace Krafted.IntegrationTest.Infrastructure.Sql.Builtin
{
    [Trait(nameof(IntegrationTest), nameof(Infrastructure))]
    public class BultinSqlBuilderTest : IntegrationTest<InfrastructureStartup>, IClassFixture<ProviderStateApiFactory<InfrastructureStartup>>
    {
        private readonly ISqlBuilder _sqlBuilder;

        public BultinSqlBuilderTest(ProviderStateApiFactory<InfrastructureStartup> factory)
            : base(factory, "http://localhost:5001/api/v1")
        {
            var connectionProvider = new SqlServerConnectionProvider(ConfigurationHelper.GetConnectionString("InfrastructureConnection"));
            var connection = connectionProvider.Create();

            _sqlBuilder = SqlBuilderFactory.NewSqlBuilder<Foo>(new BultinSqlBuilderFactory(), connection);
        }

        [Fact]
        public void GetSelectCommand_SelectCommandShouldBeGenerated()
        {
            string sql = _sqlBuilder.GetSelectCommand();
            Assert.Equal("SELECT FooId,Name,StartDate,EndDate,Canceled FROM Foo", sql);
        }

        [Fact]
        public void GetSelectByIdCommand_GetSelectByIdCommandShouldBeGenerated()
        {
            var id = Guid.NewGuid();
            string sql = _sqlBuilder.GetSelectByIdCommand(id);
            Assert.Equal($"SELECT FooId,Name,StartDate,EndDate,Canceled FROM Foo WHERE FooId = '{id}'", sql);
        }

        [Fact]
        public void GetInsertCommand_GetInsertCommandShouldBeGenerated()
        {
            string sql = _sqlBuilder.GetInsertCommand();
            Assert.Equal("INSERT INTO [Foo] ([FooId], [Name], [StartDate], [EndDate], [Canceled]) VALUES (@FooId, @Name, @StartDate, @EndDate, @Canceled)", sql);
        }

        [Fact]
        public void GetUpdateCommand_GetUpdateCommandShouldBeGenerated()
        {
            string sql = _sqlBuilder.GetUpdateCommand();
            Assert.Equal("UPDATE [Foo] SET [Name] = @Name, [StartDate] = @StartDate, [EndDate] = @EndDate, [Canceled] = @Canceled WHERE ([FooId] = @FooId)", sql);
        }

        [Fact]
        public void GetDeleteCommand_GetDeleteCommandShouldBeGenerated()
        {
            string sql = _sqlBuilder.GetDeleteCommand();
            Assert.Equal("DELETE FROM [Foo] WHERE ([FooId] = @FooId)", sql);
        }
    }
}