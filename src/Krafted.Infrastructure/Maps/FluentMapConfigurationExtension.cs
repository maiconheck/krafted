using Dapper.FluentMap.Configuration;
using SharedKernel.Domain;

namespace Krafted.Infrastructure.Maps
{
    /// <summary>
    /// Provides extension methods to <see cref="FluentMapConfiguration"/>.
    /// </summary>
    public static class FluentMapConfigurationExtension
    {
        /// <summary>
        /// Adds the <see cref="DefaultMap{TEntity}" /> mapping to the <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <param name="config">The configuration</param>
        public static void AddMap<TEntity>(this FluentMapConfiguration config)
            where TEntity : Entity => config.AddMap(new DefaultMap<TEntity>());
    }
}