using System;
using System.IO;
using Krafted.Guards;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Krafted.Configuration
{
    /// <summary>
    /// Provides an implementation of <see cref="IHostEnvironment"/>.
    /// </summary>
    public class HostEnvironment : IHostEnvironment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HostEnvironment"/> class.
        /// </summary>
        /// <param name="environmentName">Name of the environment.</param>
        /// <exception cref="ArgumentException"><paramref name="environmentName"/> is null, empty, or consists only of white-space.</exception>
        public HostEnvironment(string environmentName)
        {
            Guard.Against.NullOrWhiteSpace(environmentName, nameof(environmentName));

            EnvironmentName = environmentName;
            ContentRootPath = Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Gets or sets the name of the environment. The host automatically sets this property to the value of the
        /// of the "environment" key as specified in configuration.
        /// </summary>
        /// <value>
        /// The name of the environment.
        /// </value>
        public string EnvironmentName { get; set; }

        /// <summary>
        /// Gets or sets the name of the application. This property is automatically set by the host to the assembly containing
        /// the application entry point.
        /// </summary>
        /// <value>
        /// The name of the application.
        /// </value>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets the absolute path to the directory that contains the application content files.
        /// </summary>
        /// <value>
        /// The absolute path to the directory that contains the application content files.
        /// </value>
        public string ContentRootPath { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="IFileProvider" /> pointing at <see cref="IHostEnvironment.ContentRootPath" />.
        /// </summary>
        /// <value>
        /// An <see cref="IFileProvider" /> pointing at <see cref="IHostEnvironment.ContentRootPath" />.
        /// </value>
        public IFileProvider ContentRootFileProvider { get; set; }
    }
}
