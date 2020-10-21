using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Krafted.Configuration
{
    /// <summary>
    /// Provides a singleton to the <see cref="IConfiguration"/>
    /// with some common providers sets to the <see cref="ConfigurationBuilder"/>.
    /// </summary>
    public sealed class Config
    {
        private static IConfiguration _configuration;

        private static IHostEnvironment _environment;

        /// <summary>
        /// Prevents a default instance of the <see cref="Config"/> class from being created.
        /// </summary>
        [ExcludeFromCodeCoverage]
        private Config()
        {
        }

        /// <summary>
        /// Gets the <see cref="IConfiguration"/> singleton instance.
        /// After you get the instance from an specific EnvironmentName (e.g. Development),
        /// if you call this method again you ever get the same instance, except if you pass other <see cref="IHostEnvironment"/>
        /// with a different EnvironmentName (e.g. Production).
        /// In this case, a new instance will be created for that environment.
        /// </summary>
        /// <param name="environment">The <see cref="IHostEnvironment"/>.</param>
        /// <returns>The <see cref="IConfiguration"/> singleton instance.</returns>
        public static IConfiguration Instance(IHostEnvironment environment)
        {
            if (_configuration is null || _environment.EnvironmentName != environment.EnvironmentName)
            {
                _environment = environment;
                Initialize(_environment);
            }

            return _configuration;
        }

        /// <summary>
        /// Gets the <see cref="IConfiguration"/> singleton instance.
        /// After you get the instance from an specific EnvironmentName (e.g. Development),
        /// if you call this method again you ever get the same instance, except if you change the <c>ASPNETCORE_ENVIRONMENT</c> variable
        /// with a different value (e.g. Production).
        /// In this case, a new instance will be created for that environment.
        /// </summary>
        /// <returns>The <see cref="IConfiguration"/> singleton instance.</returns>
        /// <exception cref="InvalidOperationException">Occurs if the the ASPNETCORE_ENVIRONMENT variable was not found.</exception>
        public static IConfiguration Instance()
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (environment is null)
            {
                throw new InvalidOperationException("The ASPNETCORE_ENVIRONMENT variable was not found.");
            }

            if (_configuration is null || _environment.EnvironmentName != environment)
            {
                _environment = new HostEnvironment(environment);
                Initialize(_environment);
            }

            return _configuration;
        }

        /// <summary>
        /// Initializes the <see cref="IConfiguration"/> with the JSON configuration provider, for the specified environment.
        /// </summary>
        /// <param name="env">The <see cref="IHostEnvironment"/>.</param>
        private static void Initialize(IHostEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
