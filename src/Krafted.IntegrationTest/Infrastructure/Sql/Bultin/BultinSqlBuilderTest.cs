using System;
using Krafted.Api;
using Krafted.Infrastructure.Connections.SqlServer;
using Krafted.Infrastructure.Sql;
using Krafted.Infrastructure.Sql.Bultin;
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

            _sqlBuilder = SqlBuilderFactory.NewSqlBuilder<DummyModel>(new BultinSqlBuilderFactory(), connection);
        }

        [Fact]
        public void GetSelectCommand_SelectCommandShouldBeGenerated()
        {
            string sql = _sqlBuilder.GetSelectCommand();
            Assert.Equal("SELECT DummyModelId,Name,StartDate,EndDate,Canceled FROM DummyModel", sql);
        }

        [Fact]
        public void GetSelectByIdCommand_GetSelectByIdCommandShouldBeGenerated()
        {
            var id = Guid.NewGuid();
            string sql = _sqlBuilder.GetSelectByIdCommand(id);
            Assert.Equal($"SELECT DummyModelId,Name,StartDate,EndDate,Canceled FROM DummyModel WHERE DummyModelId = '{id}'", sql);
        }

        [Fact]
        public void GetInsertCommand_GetInsertCommandShouldBeGenerated()
        {
            string sql = _sqlBuilder.GetInsertCommand();
            Assert.Equal("INSERT INTO [DummyModel] ([DummyModelId], [Name], [StartDate], [EndDate], [Canceled]) VALUES (@DummyModelId, @Name, @StartDate, @EndDate, @Canceled)", sql);
        }

        [Fact]
        public void GetUpdateCommand_GetUpdateCommandShouldBeGenerated()
        {
            string sql = _sqlBuilder.GetUpdateCommand();
            Assert.Equal("UPDATE [DummyModel] SET [Name] = @Name, [StartDate] = @StartDate, [EndDate] = @EndDate, [Canceled] = @Canceled WHERE ([DummyModelId] = @DummyModelId)", sql);
        }

        [Fact]
        public void GetDeleteCommand_GetDeleteCommandShouldBeGenerated()
        {
            string sql = _sqlBuilder.GetDeleteCommand();
            Assert.Equal("DELETE FROM [DummyModel] WHERE ([DummyModelId] = @DummyModelId)", sql);
        }
    }
}