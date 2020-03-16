using System.Data;
using System.Data.SqlClient;
using Krafted.Data.Connection;

namespace Krafted.Data.SqlServer.Connection
{
    /// <summary>
    /// Represents a SqlServerConnectionProvider.
    /// Implements the <see cref="IConnectionProvider" />.
    /// </summary>
    /// <seealso cref="IConnectionProvider" />
    public class SqlServerConnectionProvider : IConnectionProvider
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerConnectionProvider"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public SqlServerConnectionProvider(string connectionString)
        {
            ExceptionHelper.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));
            _connectionString = connectionString;
        }

        /// <summary>
        /// Create a connection.
        /// </summary>
        /// <returns>The connection.</returns>
        public IDbConnection Create() => new SqlConnection(_connectionString);
    }
}