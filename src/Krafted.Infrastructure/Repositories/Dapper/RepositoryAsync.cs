using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using SharedKernel.Domain;
using SharedKernel.Transactions;

namespace Krafted.Infrastructure.Repositories.Dapper
{
    /// <summary>
    /// Represents an generic repository.
    /// Implements the <see cref="Repository" />
    /// Implements the <see cref="IRepositoryAsync{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <seealso cref="Repository" />
    /// <seealso cref="IRepositoryAsync{TEntity}" />
    public class RepositoryAsync<TEntity> : Repository, IRepositoryAsync<TEntity>
        where TEntity : Entity
    {
        private readonly SqlBuilder<TEntity> _queryBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryAsync{TEntity}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public RepositoryAsync(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _queryBuilder = new SqlBuilder<TEntity>(Connection);
        }

        /// <summary>
        /// Gets all entities asynchronous.
        /// </summary>
        /// <returns>The entities</returns>
        public Task<IEnumerable<TEntity>> GetAllAsync()
            => Connection.QueryAsync<TEntity>(_queryBuilder.GetSelectCommand(), null, Transaction);

        /// <summary>
        /// Gets all entities asynchronous based on a criteria.
        /// </summary>
        /// <param name="whereConditions">The where conditions.</param>
        /// <returns>The entities</returns>
        /// <exception cref="NotImplementedException">WIP</exception>
        public Task<IEnumerable<TEntity>> GetAllAsync(object whereConditions) => throw new NotImplementedException();

        /// <summary>
        /// Gets an entity by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns>The entity</returns>
        public Task<TEntity> GetByIdAsync(Guid id)
            => Connection.QueryFirstAsync<TEntity>(_queryBuilder.GetSelectByIdCommand(id), id, Transaction);

        /// <summary>
        /// Creates a new entity asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="param">The parameters.</param>
        /// <returns>The task</returns>
        public async Task CreateAsync(TEntity entity, object param = null)
            => await Connection.ExecuteAsync(_queryBuilder.GetInsertCommand(), param ?? GetParams(entity), Transaction).ConfigureAwait(false);

        /// <summary>
        /// Updates the specified entity asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="param">The parameters.</param>
        /// <returns>The task</returns>
        public async Task UpdateAsync(TEntity entity, object param = null)
            => await ExecuteAsync(_queryBuilder.GetUpdateCommand(), param ?? GetParams(entity)).ConfigureAwait(false);

        /// <summary>
        /// Deletes the specified entity asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The task</returns>
        public async Task DeleteAsync(TEntity entity) =>
            await ExecuteAsync(_queryBuilder.GetDeleteCommand(), GetParam(entity)).ConfigureAwait(false);

        /// <summary>
        /// Extract the entity parameters.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The entity parameters.</returns>
        private static object GetParams(TEntity entity) => entity.ToParams(typeof(TEntity).Name);

        /// <summary>
        /// Extract the entity parameters.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The entity parameters.</returns>
        private static object GetParam(TEntity entity) => entity.ToParam(typeof(TEntity).Name);

        /// <summary>
        /// Execute a command asynchronously.
        /// </summary>
        /// <param name="sql">The SQL statement to execute.</param>
        /// <param name="param">The parameters to use for this SQL.</param>
        /// <returns>The number of rows affected.</returns>
        private async Task ExecuteAsync(string sql, object param)
            => await Connection.ExecuteAsync(sql, param, Transaction).ConfigureAwait(false);
    }
}