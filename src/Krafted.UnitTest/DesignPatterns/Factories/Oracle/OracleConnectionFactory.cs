using Krafted.DesignPatterns.Factories;

namespace Krafted.UnitTest.DesignPatterns.Factories.Oracle
{
    /// <summary>
    /// Represents the ConcreteFactory [Gamma et al.] OracleConnectionFactory.
    /// </summary>
    public class OracleConnectionFactory : AbstractFactory
    {
        /// <summary>
        /// Creates a Oracle connection.
        /// </summary>
        /// <returns>The Oracle connection.</returns>
        public override IAbstractProduct New() => new OracleConnection();
    }
}
