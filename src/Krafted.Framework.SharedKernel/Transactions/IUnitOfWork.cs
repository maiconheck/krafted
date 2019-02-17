using System;
using System.Data;

namespace Krafted.Framework.SharedKernel.Transactions
{
    public interface IUnitOfWork : IDisposable
    {
        IDbTransaction Transaction { get; }

        IDbConnection Connection { get; }

        void Commit();
    }
}