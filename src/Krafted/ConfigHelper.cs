using Microsoft.Extensions.Configuration;

namespace Krafted
{
    /// <summary>
    /// Provides helper methods to get connection strings and settings from appSettings.json through the <see cref="IConfiguration"/> provider.
    /// </summary>
    public sealed class ConfigHelper
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigHelper"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ConfigHelper(IConfiguration configuration) => _configuration = configuration;

        /// <summary>
        /// Gets the connection string by name.
        /// The name of the connection string. The default value is 'StandardConnection'
        /// that may be used by convention over configuration (CoC).
        /// </summary>
        /// <param name="connectionStringName">
        /// The name of the connection string. The default value is 'StandardConnection'
        /// that may be used by convention over configuration (CoC).
        /// </param>
        /// <returns>The connection string.</returns>
        public string GetConnectionString(string connectionStringName = "StandardConnection")
            => _configuration.GetConnectionString(connectionStringName);
    }
}