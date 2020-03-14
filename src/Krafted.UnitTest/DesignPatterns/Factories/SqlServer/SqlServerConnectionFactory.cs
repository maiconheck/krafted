using Krafted.DesignPatterns.Factories;

namespace Krafted.UnitTest.DesignPatterns.Factories.SqlServer
{
    /// <summary>
    /// Represents the ConcreteFactory [Gamma et al.] SqlServerConnectionFactory.
    /// </summary>
    public class SqlServerConnectionFactory : AbstractFactory
    {
        /// <summary>
        /// Creates a SQL Server connection.
        /// </summary>
        /// <returns>The SQL Server connection.</returns>
        public override IAbstractProduct New() => new SqlConnection();
    }
}