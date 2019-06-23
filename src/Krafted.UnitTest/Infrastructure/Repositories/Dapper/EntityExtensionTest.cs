using System;
using System.Linq;
using Krafted.Infrastructure.Repositories.Dapper;
using Krafted.IntegrationTest.FooBar.Domain;
using Xunit;

namespace Krafted.UnitTest.Infrastructure.Repositories.Dapper
{
    [Trait(nameof(UnitTest), nameof(Infrastructure))]
    public class EntityExtensionTest
    {
        [Fact]
        public void GetColumnNames_Foo_ShouldBeGot()
        {
            var foo = new Foo("Name", DateTime.Today, DateTime.Today.AddDays(1));
            var columns = foo.GetColumnNames(nameof(Foo));

            Assert.Equal(5, columns.Count);
            Assert.Equal("FooId", columns[0]);
            Assert.Equal("Name", columns[1]);
            Assert.Equal("StartDate", columns[2]);
            Assert.Equal("EndDate", columns[3]);
            Assert.Equal("Canceled", columns[4]);
        }

        [Fact]
        public void ToParams_Foo_ShouldBeConvert()
        {
            var foo = new Foo("Name", DateTime.Today, DateTime.Today.AddDays(1));
            var parameters = foo.ToParams(nameof(Foo)).ParameterNames.ToList();

            Assert.Equal(5, parameters.Count);
            Assert.Equal("FooId", parameters[0]);
            Assert.Equal("Name", parameters[1]);
            Assert.Equal("StartDate", parameters[2]);
            Assert.Equal("EndDate", parameters[3]);
            Assert.Equal("Canceled", parameters[4]);
        }

        [Fact]
        public void ToParam_Foo_ShouldBeConvert()
        {
            var foo = new Foo("Name", DateTime.Today, DateTime.Today.AddDays(1));
            var parameters = foo.ToParam(nameof(Foo)).ParameterNames.ToList();

            Assert.Single(parameters);
            Assert.Equal("FooId", parameters[0]);
        }
    }
}