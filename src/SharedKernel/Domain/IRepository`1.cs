using System;
using System.Collections.Generic;

namespace SharedKernel.Domain
{
    public interface IRepository<TEntity> : IRepository
        where TEntity : Entity
    {
        TEntity GetById(Guid id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(object whereConditions);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(Guid id);
    }
}