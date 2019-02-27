using System.Data;

namespace Krafted.Infrastructure.Connections
{
    public interface IConnectionProvider
    {
        IDbConnection Create();
    }
}
