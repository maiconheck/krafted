using System.Data;
using Krafted.Framework.SharedKernel.Transactions;

namespace Krafted.Infrastructure.Repositories.Dapper
{
    public abstract class Repository
    {
        protected Repository(IUnitOfWork unitOfWork) => Transaction = unitOfWork.Transaction;

        protected IDbTransaction Transaction { get; set; }

        protected IDbConnection Connection => Transaction.Connection;
    }
}