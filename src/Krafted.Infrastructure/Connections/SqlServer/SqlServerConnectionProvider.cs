using System.Data;
using System.Data.SqlClient;

namespace Krafted.Infrastructure.Connections.SqlServer
{
    /// <summary>
    /// Represents a SqlServerConnectionProvider.
    /// Implements the <see cref="IConnectionProvider" />
    /// </summary>
    /// <seealso cref="IConnectionProvider" />
    public class SqlServerConnectionProvider : IConnectionProvider
    {
        private readonly string _configurationString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerConnectionProvider"/> class.
        /// </summary>
        /// <param name="configurationString">The configuration string.</param>
        public SqlServerConnectionProvider(string configurationString)
        {
            _configurationString = configurationString;
        }

        /// <summary>
        /// Create a connection.
        /// </summary>
        /// <returns>The connection</returns>
        public IDbConnection Create() => new SqlConnection(_configurationString);
    }
}