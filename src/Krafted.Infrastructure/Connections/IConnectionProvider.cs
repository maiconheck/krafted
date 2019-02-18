using System.Data.Common;
using Krafted.Infrastructure.Connections.SqlServer;

namespace Krafted.Infrastructure.Connections
{
    public interface IConnectionProvider
    {
        DbConnection Create(ConnectionType type);
    }
}
