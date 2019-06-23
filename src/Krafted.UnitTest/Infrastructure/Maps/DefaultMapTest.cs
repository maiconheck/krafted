using Dapper.FluentMap.Dommel.Mapping;
using Krafted.Infrastructure.Maps;
using Krafted.IntegrationTest.FooBar.Domain;
using Xunit;

namespace Krafted.UnitTest.Infrastructure.Maps
{
    [Trait(nameof(UnitTest), nameof(Infrastructure))]
    public class DefaultMapTest
    {
        [Fact]
        public void DefaultMap_Foo_FooShouldBeMapped()
        {
            var map = new DefaultMap<Foo>();

            var id = map.PropertyMaps[0] as DommelPropertyMap;
            var invalid = map.PropertyMaps[1] as DommelPropertyMap;
            var valid = map.PropertyMaps[2] as DommelPropertyMap;
            var notification = map.PropertyMaps[3] as DommelPropertyMap;

            Assert.Equal(4, map.PropertyMaps.Count);
            Assert.Equal("FooId", id.ColumnName);
            Assert.True(id.Key);
            Assert.True(invalid.Ignored);
            Assert.True(valid.Ignored);
            Assert.True(notification.Ignored);
        }
    }
}