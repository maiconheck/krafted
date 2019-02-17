using System.Data.Common;
using Krafted.Framework.Infrastructure.Connections.SqlServer;

namespace Krafted.Framework.Infrastructure.Connections
{
    public interface IConnectionProvider
    {
        DbConnection Create(ConnectionType type);
    }
}
