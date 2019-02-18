using Microsoft.Extensions.Options;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace Krafted.Infrastructure.Connections.SqlServer
{
    public class SqlServerConnectionProvider : IConnectionProvider
    {
        private readonly IOptions<ConnectionProviderOptions> _connectionProviderOptions;

        public SqlServerConnectionProvider(IOptions<ConnectionProviderOptions> connectionProviderOptions)
        {
            _connectionProviderOptions = connectionProviderOptions;
        }

        public DbConnection Create(ConnectionType type)
        {
            if (_connectionProviderOptions.Value == null)
                throw new ArgumentNullException("There's no ConnectionStrings configuration section registered. Please, register the section in appsettings.json or user secrets.");

            if (string.IsNullOrEmpty(_connectionProviderOptions.Value?.StandardConnection))
                throw new ArgumentNullException("There's no ConnectionStrings:StandardConnection configured. Please, register the value.");

            return (type == ConnectionType.StandardConnection)
                ? new SqlConnection(_connectionProviderOptions.Value.StandardConnection)
                : new SqlConnection(_connectionProviderOptions.Value.LogConnection);
        }
    }
}
