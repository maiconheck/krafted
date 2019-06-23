using System;
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
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerConnectionProvider"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public SqlServerConnectionProvider(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("The connection string is invalid.");

            _connectionString = connectionString;
        }

        /// <summary>
        /// Create a connection.
        /// </summary>
        /// <returns>The connection</returns>
        public IDbConnection Create() => new SqlConnection(_connectionString);
    }
}