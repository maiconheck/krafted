using System.Data;
using System.Data.SqlClient;

namespace Krafted.Data.Connection.SqlServer
{
    /// <summary>
    /// Represents the ConcreteFactory [Gamma et al.] SqlServerConnectionFactory.
    /// </summary>
    public class SqlServerConnectionFactory : IConnectionFactory
    {
        /// <summary>
        /// Create a SQL Server connection.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The SQL Server connection.</returns>
        public IDbConnection NewConnection(string connectionString) => new SqlConnection(connectionString);
    }
}