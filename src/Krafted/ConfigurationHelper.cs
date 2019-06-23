using System.IO;
using Microsoft.Extensions.Configuration;

namespace Krafted
{
    /// <summary>
    /// Provides helper methods to get connection strings and settings from appSettings.json throw the <see cref="IConfiguration"/> provider.
    /// </summary>
    public static class ConfigurationHelper
    {
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
        public static string GetConnectionString(string connectionStringName = "StandardConnection")
            => BuildConfiguration().GetConnectionString(connectionStringName);

        /// <summary>
        /// Builds the <see cref="IConfiguration"/>.
        /// </summary>
        /// <returns>The <see cref="IConfiguration"/>.</returns>
        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();
        }
    }
}