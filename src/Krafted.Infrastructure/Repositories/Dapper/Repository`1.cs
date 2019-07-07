using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Dapper;
using Krafted.Infrastructure.Sql;
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
    [SuppressMessage("Usage", "CC0057:Unused parameters", Justification = "WIP")]
    [SuppressMessage("Design", "CC0091:Use static method", Justification = "WIP")]
    public class Repository<TEntity> : Repository, IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly ISqlBuilder _queryBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="factory">The SqlBuilder abstract factory.</param>
        public Repository(IUnitOfWork unitOfWork, ISqlBuilderFactory factory)
            : base(unitOfWork) => _queryBuilder = SqlBuilderFactory.NewSqlBuilder<TEntity>(factory, Connection);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>The entities</returns>
        public IEnumerable<TEntity> GetAll()
            => Connection.Query<TEntity>(_queryBuilder.GetSelectCommand(), null, Transaction);

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
        public TEntity GetById(Guid id)
            => Connection.QueryFirstOrDefault<TEntity>(_queryBuilder.GetSelectByIdCommand(id), id, Transaction);

        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="param">The parameters.</param>
        public virtual void Create(TEntity entity, object param = null)
            => Connection.Execute(_queryBuilder.GetInsertCommand(), param ?? GetParams(entity), Transaction);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="param">The parameters.</param>
        public virtual void Update(TEntity entity, object param = null)
            => Execute(_queryBuilder.GetUpdateCommand(), param ?? GetParams(entity));

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TEntity entity)
            => Execute(_queryBuilder.GetDeleteCommand(), entity.ToParam(typeof(TEntity).Name));

        /// <summary>
        /// Extract the entity parameters.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The entity parameters.</returns>
        private static object GetParams(TEntity entity) => entity.ToParams(typeof(TEntity).Name);

        /// <summary>
        /// Execute a command.
        /// </summary>
        /// <param name="sql">The SQL statement to execute.</param>
        /// <param name="param">The parameters to use for this SQL.</param>
        private void Execute(string sql, object param) => Connection.Execute(sql, param, Transaction);
    }
}