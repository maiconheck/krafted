using Dapper.FluentMap.Configuration;
using Krafted.Infrastructure.Maps;
using Krafted.IntegrationTest.FooBar.Domain;
using Xunit;

namespace Krafted.UnitTest.Infrastructure.Maps
{
    [Trait(nameof(UnitTest), nameof(Infrastructure))]
    public class FluentMapConfigurationExtensionTest
    {
        [Fact]
        public void AddMap_DefaultMap_ShouldBeAdded()
        {
            var config = new FluentMapConfiguration();
            config.AddMap(new DefaultMap<Foo>());
        }
    }
}