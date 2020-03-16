using System;
using System.Collections.Generic;
using System.Linq;
using Krafted.Data;
using Krafted.Data.SqlServer.Dapper;
using Xunit;
using Assert = Krafted.Test.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class EntityTest
    {
        [Fact]
        public void SetNewId_Id_GetId()
        {
            const string emptyId = "00000000-0000-0000-0000-000000000000";
            var entity = new EntityDummy();

            Assert.Equal(emptyId, entity.Id.ToString());
            entity.SetNewId();
            Assert.NotEqual(emptyId, entity.Id.ToString());
        }

        [Fact]
        public void AddNotificationsIfInvalid_InvalidNotifications_InvalidNotifications()
        {
            var validModel = new EntityDummy("abcde");
            var invalidModel1 = new EntityDummy("abcdef");
            var invalidModel2 = new EntityDummy("abcdef");

            var entity = new EntityDummy();
            entity.AddNotificationsIfInvalid(validModel, invalidModel1, invalidModel2);

            Assert.True(entity.Invalid);
            Assert.Equal(2, entity.Notifications.Count);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ToParam_NullOrEmpty_ThrowsException(string tableName)
            => Assert.Throws<ArgumentException>(() => new EntityDummy().ToParam(tableName));

        [Fact]
        public void ToParam_Dummy_DoesNotThrowsException() => Assert.DoesNotThrows(() => new EntityDummy().ToParam("Dummy"));

        [Fact]
        public void ToParam_Dummy_Param()
        {
            var entity = new EntityDummy();
            entity.SetNewId();
            var param = entity.ToParam("Dummy");
            var paramNames = param.ParameterNames.ToList();

            Assert.Single(paramNames);
            Assert.Equal("DummyId", param.ParameterNames.First());
            Assert.Equal(entity.Id, param.Get<Guid>("DummyId"));
        }

        [Fact]
        public void ToParams_Dummy_Params()
        {
            var entity = new EntityDummy("The foo", "The bar");
            var @params = entity.ToParams("Dummy");

            Assert.Equal("DummyId", @params.ParameterNames.First());
            Assert.Equal(entity.Id, @params.Get<Guid>("DummyId"));

            Assert.Equal("Foo", @params.ParameterNames.Second());
            Assert.Equal("The foo", @params.Get<string>("Foo"));

            Assert.Equal("Bar", @params.ParameterNames.Third());
            Assert.Equal("The bar", @params.Get<string>("Bar"));
        }

        [Fact]
        public void GetColumnNames_Foo_ShouldBeGot()
        {
            var entity = new EntityDummy();
            var columns = entity.GetColumnNames(nameof(EntityDummy));

            Assert.Equal(3, columns.Count);
            Assert.Equal("EntityDummyId", columns.First());
            Assert.Equal("Foo", columns.Second());
            Assert.Equal("Bar", columns.Third());
        }
    }
}