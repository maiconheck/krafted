// A UnitOfWork implementation for dapper.
//
// This was adapted from Tim Schreiber.
// Source: https://github.com/timschreiber/DapperUnitOfWork/blob/master/DapperUnitOfWork/UnitOfWork.cs
// Retrieved in Dezember 2017.

using System;
using System.Data;
using Krafted.Infrastructure.Connections;
using Microsoft.Extensions.Logging;
using SharedKernel.Transactions;

namespace Krafted.Infrastructure.Transactions
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger<UnitOfWork> _logger;
        
        private bool _disposed;

        public IDbTransaction Transaction { get; private set; }

        public IDbConnection Connection { get; private set; }

        public UnitOfWork(IConnectionProvider connectionProvider, ILogger<UnitOfWork> logger)
        {
            Connection = connectionProvider.Create();
            Connection.Open();
            Transaction = Connection.BeginTransaction();

            _logger = logger;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Commit()
        {
            try
            {
                Transaction.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu uma exceção no commit.");
                Transaction.Rollback();
                _logger.LogInformation("Rollback realizado com sucesso.");
            }
            finally
            {
                Transaction.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (Transaction != null)
                {
                    Transaction.Dispose();
                    Transaction = null;
                }

                if (Connection != null)
                {
                    Connection.Dispose();
                    Connection = null;
                }
            }

            _disposed = true;
        }
    }
}