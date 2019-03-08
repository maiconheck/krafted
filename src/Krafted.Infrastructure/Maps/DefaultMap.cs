using Dapper.FluentMap.Dommel.Mapping;
using SharedKernel.Domain;

namespace Krafted.Infrastructure.Maps
{
    /// <summary>
    /// Represents a entity mapper.
    /// Implements the <see cref="DommelEntityMap{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="DommelEntityMap{TEntity}" />
    public class DefaultMap<TEntity> : DommelEntityMap<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultMap{TEntity}"/> class.
        /// </summary>
        public DefaultMap()
        {
            Map(p => p.Id).ToColumn($"{typeof(TEntity).Name}Id").IsKey();
            Map(p => p.Invalid).Ignore();
            Map(p => p.Valid).Ignore();
            Map(p => p.Notifications).Ignore();
        }
    }
}