// A UnitOfWork implementation for dapper.
//
// This was adapted from Tim Schreiber.
// Source: https://github.com/timschreiber/DapperUnitOfWork/blob/master/DapperUnitOfWork/UnitOfWork.cs
// Retrieved in Dezember 2017.

using System;
using System.Data;
using Krafted.Framework.Infrastructure.Connections;
using Krafted.Framework.Infrastructure.Connections.SqlServer;
using Krafted.Framework.SharedKernel.Transactions;

namespace Krafted.Framework.Infrastructure.Transactions
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;

        public IDbTransaction Transaction { get; private set; }
        public IDbConnection Connection { get; private set; }

        public UnitOfWork(IConnectionProvider connectionProvider)
        {
            Connection = connectionProvider.Create(ConnectionType.StandardConnection);
            Connection.Open();
            Transaction = Connection.BeginTransaction();
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
                Transaction.Rollback();
                throw;
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