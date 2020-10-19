using System;
using System.IO;
using Krafted.Guards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Krafted.EntityFrameworkCore
{
    /// <summary>
    /// A factory to creating derived Microsoft.EntityFrameworkCore.DbContext instances.
    /// <see href="https://docs.microsoft.com/pt-br/ef/core/miscellaneous/cli/dbcontext-creation">See Design-time DbContext Creation</see>.
    /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.design.idesigntimedbcontextfactory-1?view=efcore-3.1">See IDesignTimeDbContextFactory{TContext} Interface</see>.
    /// </summary>
    /// <seealso cref="IDesignTimeDbContextFactory{TContext}" />
    /// <typeparam name="TContext">The type of the DbContext.</typeparam>
    public abstract class DesignTimeDbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private readonly string _connectionStringName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DesignTimeDbContextFactory{TDbContext}"/> class.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        protected DesignTimeDbContextFactory(string connectionStringName)
        {
            Guard.Against.NullOrWhiteSpace(connectionStringName, nameof(connectionStringName));
            _connectionStringName = connectionStringName;
        }

        /// <summary>
        /// Gets the options to be used by a Microsoft.EntityFrameworkCore.DbContext.
        /// </summary>
        /// <value>
        /// The options to be used by a Microsoft.EntityFrameworkCore.DbContext.
        /// </value>
        protected DbContextOptions<TContext> Options
        {
            get
            {
                var optionsBuilder = new DbContextOptionsBuilder<TContext>();
                optionsBuilder.UseSqlServer(GetConnectionString());

                return optionsBuilder.Options;
            }
        }

        /// <summary>
        /// Creates a new instance of a derived context.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time service.</param>
        /// <returns>
        /// An instance of <see name="TContext" />.
        /// </returns>
        public abstract TContext CreateDbContext(string[] args);

        private string GetConnectionString()
        {
            string basePath = Directory.GetCurrentDirectory();
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = builder.GetConnectionString(_connectionStringName);
            Guard.Against.NullOrWhiteSpace(connectionString, nameof(connectionString));

            return connectionString;
        }
    }
}
