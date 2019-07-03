using Dapper.FluentMap.Configuration;
using Krafted.Infrastructure.Maps;
using Krafted.UnitTest.Infrastructure.Repositories.Dapper;
using Xunit;

namespace Krafted.UnitTest.Infrastructure.Maps
{
    [Trait(nameof(UnitTest), nameof(Infrastructure))]
    public class FluentMapConfigurationExtensionTest
    {
        [Fact]
        public void AddDefaultMap_Foo_DefaultMapShouldBeAdded()
        {
            var config = new FluentMapConfiguration();
            config.AddMap<Foo>();
        }
    }
}