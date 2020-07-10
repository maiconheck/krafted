using System;
using System.Data;

namespace Krafted.Data.Connection
{
    /// <summary>
    /// Represents a Factory Method [Gamma et al.] to the <see cref="IDbConnection"/>.
    /// </summary>
    public static class ConnectionFactory
    {
        /// <summary>
        /// Creates a connection to a specific database provider.
        /// </summary>
        /// <typeparam name="TConnectionFactory">The type of the ConcreteFactory [Gamma et al.].</typeparam>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The connection, a.k.a. ConcreteProduct [Gamma et al.].</returns>
        public static IDbConnection NewConnection<TConnectionFactory>(string connectionString)
            where TConnectionFactory : IConnectionFactory
        {
            GuardAgainst.NullOrWhiteSpace(connectionString, nameof(connectionString));

            var factory = (TConnectionFactory)Activator.CreateInstance(typeof(TConnectionFactory));
            return factory.NewConnection(connectionString);
        }
    }
}