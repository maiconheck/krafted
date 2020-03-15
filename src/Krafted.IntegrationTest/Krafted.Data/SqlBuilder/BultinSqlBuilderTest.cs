using System;
using Krafted.Api;
using Krafted.Data.Connection;
using Krafted.Data.SqlBuilder;
using Krafted.Data.SqlServer.Connection;
using Krafted.Data.SqlServer.SqlBuilder;
using Krafted.Test;
using Xunit;

namespace Krafted.IntegrationTest.Krafted.Data.SqlBuilder
{
    [Trait(nameof(IntegrationTest), nameof(Data))]
    public class BultinSqlBuilderTest : IntegrationTest<InfrastructureStartup>, IClassFixture<ProviderStateApiFactory<InfrastructureStartup>>
    {
        private readonly ISqlBuilder _sqlBuilder;

        public BultinSqlBuilderTest(ProviderStateApiFactory<InfrastructureStartup> factory)
            : base(factory, "http://localhost:5001/api/v1")
        {
            var connectionString = Config.Instance().GetConnectionString("SqlServerConnection");
            var connection = ConnectionFactory.NewConnection<SqlServerConnectionFactory>(connectionString);

            _sqlBuilder = SqlBuilderFactory.NewSqlBuilder<EntityDummy, BultinSqlBuilderFactory>(connection);
        }

        [Fact]
        public void GetSelectCommand_SelectCommandShouldBeGenerated()
        {
            string sql = _sqlBuilder.GetSelectCommand();
            Assert.Equal("SELECT EntityDummyId,Name,StartDate,EndDate,Canceled FROM EntityDummy", sql);
        }

        [Fact]
        public void GetSelectByIdCommand_GetSelectByIdCommandShouldBeGenerated()
        {
            var id = Guid.NewGuid();
            string sql = _sqlBuilder.GetSelectByIdCommand(id);
            Assert.Equal($"SELECT EntityDummyId,Name,StartDate,EndDate,Canceled FROM EntityDummy WHERE EntityDummyId = '{id}'", sql);
        }

        [Fact]
        public void GetInsertCommand_GetInsertCommandShouldBeGenerated()
        {
            string sql = _sqlBuilder.GetInsertCommand();
            Assert.Equal("INSERT INTO [EntityDummy] ([EntityDummyId], [Name], [StartDate], [EndDate], [Canceled]) VALUES (@EntityDummyId, @Name, @StartDate, @EndDate, @Canceled)", sql);
        }

        [Fact]
        public void GetUpdateCommand_GetUpdateCommandShouldBeGenerated()
        {
            string sql = _sqlBuilder.GetUpdateCommand();
            Assert.Equal("UPDATE [EntityDummy] SET [Name] = @Name, [StartDate] = @StartDate, [EndDate] = @EndDate, [Canceled] = @Canceled WHERE ([EntityDummyId] = @EntityDummyId)", sql);
        }

        [Fact]
        public void GetDeleteCommand_GetDeleteCommandShouldBeGenerated()
        {
            string sql = _sqlBuilder.GetDeleteCommand();
            Assert.Equal("DELETE FROM [EntityDummy] WHERE ([EntityDummyId] = @EntityDummyId)", sql);
        }
    }
}