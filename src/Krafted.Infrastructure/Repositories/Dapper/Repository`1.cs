using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SharedKernel.Domain;
using SharedKernel.Transactions;

namespace Krafted.Infrastructure.Repositories.Dapper
{
    /// <summary>
    /// Represents an generic repository.
    /// Implements the <see cref="Repository" />
    /// Implements the <see cref="IRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <seealso cref="Repository" />
    /// <seealso cref="IRepository{TEntity}" />
    [SuppressMessage("Maintainability", "RCS1140:Add exception to documentation comment", Justification = "WIP")]
    [SuppressMessage("Maintainability", "RCS1079:Implement the functionality instead of throwing new NotImplementedException.", Justification = "WIP")]
    [SuppressMessage("Usage", "CC0057:Unused parameters", Justification = "WIP")]
    [SuppressMessage("Design", "CC0091:Use static method", Justification = "WIP")]
    public abstract class Repository<TEntity> : Repository, IRepository<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        protected Repository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>The entities</returns>
        public IEnumerable<TEntity> GetAll() => throw new NotImplementedException();

        /// <summary>
        /// Gets all entities based on a criteria.
        /// </summary>
        /// <param name="whereConditions">The where conditions.</param>
        /// <returns>The entities</returns>
        public IEnumerable<TEntity> GetAll(object whereConditions) => throw new NotImplementedException();

        /// <summary>
        /// Gets an entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity</returns>
        public TEntity GetById(Guid id) => throw new NotImplementedException();

        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Create(TEntity entity) => throw new NotImplementedException();

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TEntity entity) => throw new NotImplementedException();

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TEntity entity) => throw new NotImplementedException();

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id) => throw new NotImplementedException();
    }
}