using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Krafted.Framework.Infrastructure.Repositories.Dapper;
using Krafted.Framework.IntegrationTest.FooBar.Domain;
using Krafted.Framework.SharedKernel;
using Krafted.Framework.SharedKernel.Domain;

namespace Krafted.Framework.IntegrationTest.FooBar.Infrastructure
{
    public class FooRepository : Repository, IRepositoryAsync<Foo>
    {
        public FooRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Foo>> GetAllAsync()
        {
            return await Connection
                .QueryAsync<Foo>("GetAllFoo", null, Transaction, null, CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task<Foo> GetByIdAsync(Guid id)
        {
            return await Connection
                .QueryFirstOrDefaultAsync<Foo>("GetFooById", new { id }, Transaction, null, CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task CreateAsync(Foo entity, object param = null)
        {
            await Connection.ExecuteAsync(
                "CreateFoo",
                new { entity.Id, entity.Name, entity.StartDate, entity.EndDate },
                Transaction,
                null,
                CommandType.StoredProcedure)
                .ConfigureAwait(false);
        }

        public async Task UpdateAsync(Foo entity, object param = null)
            => await ExecuteAsync("ChangeScheduleFoo", new { entity.Id, entity.StartDate, entity.EndDate });

        public async Task DeleteAsync(Guid id) => await ExecuteAsync("DeleteFoo", new { id });

        private async Task ExecuteAsync(string procedure, object param)
            => await Connection.ExecuteAsync(procedure, param, Transaction, null, CommandType.StoredProcedure).ConfigureAwait(false);

        public Task<IEnumerable<Foo>> GetAllAsync(object whereConditions)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Foo entity)
        {
            throw new NotImplementedException();
        }
    }
}