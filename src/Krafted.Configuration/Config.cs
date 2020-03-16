using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Krafted.Configuration
{
    /// <summary>
    /// Represents a wrapper for the <see cref="IConfiguration"/> implemented as a singleton.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public sealed class Config
    {
        private static ConfigHelper _configuration;

        /// <summary>
        /// Prevents a default instance of the <see cref="Config"/> class from being created.
        /// </summary>
        private Config()
        {
        }

        /// <summary>
        /// Gets the <see cref="ConfigHelper"/> singleton instance.
        /// </summary>
        /// <returns>The <see cref="ConfigHelper"/> singleton instance.</returns>
        public static ConfigHelper Instance()
        {
            if (_configuration is null)
                Initialize();

            return _configuration;
        }

        /// <summary>
        /// Initializes the <see cref="IConfiguration"/>.
        /// </summary>
        private static void Initialize()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();

            _configuration = new ConfigHelper(configuration);
        }
    }
}