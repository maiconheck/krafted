using Dapper.FluentMap.Dommel.Mapping;
using SharedKernel.Domain;

namespace Krafted.Infrastructure.Maps
{
    public class DefaultMap<TEntity> : DommelEntityMap<TEntity>
        where TEntity : Entity
    {
        public DefaultMap()
        {
            Map(p => p.Id).ToColumn($"{typeof(TEntity).Name}Id").IsKey();
            Map(p => p.Invalid).Ignore();
            Map(p => p.Valid).Ignore();
            Map(p => p.Notifications).Ignore();
        }
    }
}