using System.Data;

namespace Krafted.Data.Connection
{
    /// <summary>
    /// Interface IConnectionProvider.
    /// </summary>
    public interface IConnectionProvider
    {
        /// <summary>
        /// Create a connection.
        /// </summary>
        /// <returns>The connection.</returns>
        IDbConnection Create();
    }
}