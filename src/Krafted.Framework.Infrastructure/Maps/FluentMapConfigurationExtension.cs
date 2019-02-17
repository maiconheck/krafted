using Dapper.FluentMap.Configuration;
using Krafted.Framework.SharedKernel.Domain;

namespace Krafted.Framework.Infrastructure.Maps
{
    public static class FluentMapConfigurationExtension
    {
        public static void AddMap<TEntity>(this FluentMapConfiguration config)
            where TEntity : Entity
        {
            config.AddMap(new DefaultMap<TEntity>());
        }
    }
}