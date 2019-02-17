using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Krafted.Framework.SharedKernel.Domain
{
    public interface IRepositoryAsync<TEntity> : IRepository
        where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllAsync(object whereConditions);

        Task CreateAsync(TEntity entity, object param = null);

        Task UpdateAsync(TEntity entity, object param = null);

        Task DeleteAsync(TEntity entity);
    }
}