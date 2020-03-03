using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Krafted.Data.Connection.SqlServer
{
    /// <summary>
    /// Represents the ConcreteFactory [Gamma et al.] OracleConnectionFactory.
    /// </summary>
    public class OracleConnectionFactory : IConnectionFactory
    {
        /// <summary>
        /// Create a Oracle connection.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The Oracle connection.</returns>
        public IDbConnection NewConnection(string connectionString) => new OracleConnection(connectionString);
    }
}