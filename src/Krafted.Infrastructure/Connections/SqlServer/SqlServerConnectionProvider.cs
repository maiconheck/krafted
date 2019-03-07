using System.Data;
using System.Data.SqlClient;

namespace Krafted.Infrastructure.Connections.SqlServer
{
    public class SqlServerConnectionProvider : IConnectionProvider
    {
        private readonly string _configurationString;

        public SqlServerConnectionProvider(string configurationString)
        {        
            _configurationString = configurationString;
        }

        public IDbConnection Create() => new SqlConnection(_configurationString);
    }
}