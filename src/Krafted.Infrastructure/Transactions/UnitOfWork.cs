// A UnitOfWork implementation for dapper.
//
// This class was adapted from Tim Schreiber.
// Source: https://github.com/timschreiber/DapperUnitOfWork/blob/master/DapperUnitOfWork/UnitOfWork.cs
// Retrieved in December 2017.

using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Krafted.Infrastructure.Connections;
using Microsoft.Extensions.Logging;
using SharedKernel.Transactions;

namespace Krafted.Infrastructure.Transactions
{
    /// <summary>
    /// Provide a UnitOfWork implementation. This class cannot be inherited.
    /// Implements the <see cref="IUnitOfWork" />.
    /// </summary>
    /// <seealso cref="IUnitOfWork" />
    [ExcludeFromCodeCoverage]
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger<UnitOfWork> _logger;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="connectionProvider">The connection provider.</param>
        /// <param name="logger">The logger.</param>
        public UnitOfWork(IConnectionProvider connectionProvider, ILogger<UnitOfWork> logger)
        {
            ExceptionHelper.ThrowIfNull(() => connectionProvider, () => logger);
            Connection = connectionProvider.Create();
            Connection.Open();
            Transaction = Connection.BeginTransaction();

            _logger = logger;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        ~UnitOfWork() => Dispose(false);

        /// <summary>
        /// Gets the transaction.
        /// </summary>
        /// <value>The transaction.</value>
        public IDbTransaction Transaction { get; private set; }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>The connection.</value>
        public IDbConnection Connection { get; private set; }

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        public void Commit()
        {
            try
            {
                Transaction.Commit();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "An exception occurred in commit.");
                Transaction.Rollback();
                _logger.LogInformation("Rollback successfully performed.");
            }
            finally
            {
                Transaction.Dispose();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Transaction?.Dispose();
                Transaction = null;

                Connection?.Dispose();
                Connection = null;
            }

            _disposed = true;
        }
    }
}