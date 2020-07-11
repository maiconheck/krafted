using System;
using System.Collections.Generic;
using System.Linq;
using Krafted.Data;
using Krafted.Data.SqlServer.Dapper;
using Xunit;
using Assert = Krafted.Test.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Data.SqlServer.Dapper
{
    public class EntityDummy : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDummy"/> class.
        /// </summary>
        public EntityDummy()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDummy"/> class.
        /// </summary>
        /// <param name="foo">The foo.</param>
        /// <param name="bar">The bar.</param>
        public EntityDummy(string foo, string bar = "")
        {
            Foo = foo;
            Bar = bar;
        }

        public string Foo { get; }

        public string Bar { get; }
    }

    [Trait(nameof(UnitTest), nameof(Krafted.Data.SqlServer))]
    public class EntityExtensionTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ToParam_NullOrEmpty_ThrowsException(string tableName)
            => Assert.Throws<ArgumentNullException>(() => new EntityDummy().ToParam(tableName));

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
