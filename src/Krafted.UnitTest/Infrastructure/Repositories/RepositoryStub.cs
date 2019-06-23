using System.Data;
using Krafted.Infrastructure.Repositories.Dapper;

namespace Krafted.UnitTest.Infrastructure.Repositories
{
    public class RepositoryStub : Repository
    {
        public RepositoryStub(SharedKernel.Transactions.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public new IDbTransaction Transaction => base.Transaction;

        public new IDbConnection Connection => base.Connection;
    }
}