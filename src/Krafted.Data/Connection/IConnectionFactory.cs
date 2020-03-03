using System.Data;

namespace Krafted.Data.Connection
{
    /// <summary>
    /// The AbstractFactory participant [Gamma et al.].
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Create a connection.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The connection.</returns>
        IDbConnection NewConnection(string connectionString);
    }
}