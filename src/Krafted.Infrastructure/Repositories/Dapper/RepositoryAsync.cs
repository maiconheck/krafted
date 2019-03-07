using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using SharedKernel.Domain;
using SharedKernel.Transactions;

namespace Krafted.Infrastructure.Repositories.Dapper
{
    public class RepositoryAsync<TEntity> : Repository, IRepositoryAsync<TEntity>
        where TEntity : Entity
    {
        private readonly QueryBuilder<TEntity> _queryBuilder;

        public RepositoryAsync(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _queryBuilder = new QueryBuilder<TEntity>(Connection);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
            => Connection.QueryAsync<TEntity>(_queryBuilder.GetSelectCommand(), null, Transaction);

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
        public async Task<IEnumerable<TEntity>> GetAllAsync(object whereConditions) => throw new NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

        public Task<TEntity> GetByIdAsync(Guid id)
            => Connection.QueryFirstAsync<TEntity>(_queryBuilder.GetSelectByIdCommand(id), id, Transaction);

        public async Task CreateAsync(TEntity entity, object param = null)
            => await Connection.ExecuteAsync(_queryBuilder.GetInsertCommand(), param ?? GetParams(entity), Transaction).ConfigureAwait(false);

        public async Task UpdateAsync(TEntity entity, object param = null)
            => await ExecuteAsync(_queryBuilder.GetUpdateCommand(), param ?? GetParams(entity)).ConfigureAwait(false);

        public async Task DeleteAsync(TEntity entity) =>
            await ExecuteAsync(_queryBuilder.GetDeleteCommand(), GetParam(entity)).ConfigureAwait(false);

        private static object GetParams(TEntity entity) => entity.ToParams(typeof(TEntity).Name);

        private static object GetParam(TEntity entity) => entity.ToParam(typeof(TEntity).Name);

        private async Task ExecuteAsync(string query, object param)
            => await Connection.ExecuteAsync(query, param, Transaction).ConfigureAwait(false);
    }
}