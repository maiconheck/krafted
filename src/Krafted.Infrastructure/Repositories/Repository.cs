using System.Data;
using SharedKernel.Transactions;

namespace Krafted.Infrastructure.Repositories.Dapper
{
    /// <summary>
    /// Represents an abstract repository.
    /// </summary>
    public abstract class Repository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        protected Repository(IUnitOfWork unitOfWork)
        {
            unitOfWork.ThrowIfNull(nameof(unitOfWork));
            Transaction = unitOfWork.Transaction;
        }

        /// <summary>
        /// Gets or sets the transaction.
        /// </summary>
        /// <value>The transaction.</value>
        protected IDbTransaction Transaction { get; set; }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>The connection.</value>
        protected IDbConnection Connection => Transaction.Connection;
    }
}