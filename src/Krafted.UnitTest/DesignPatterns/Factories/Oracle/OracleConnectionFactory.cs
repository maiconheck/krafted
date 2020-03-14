using Krafted.DesignPatterns.Factories;

namespace Krafted.UnitTest.DesignPatterns.Factories.Oracle
{
    /// <summary>
    /// Represents the ConcreteFactory [Gamma et al.] OracleConnectionFactory.
    /// </summary>
    public class OracleConnectionFactory :
        IAbstractFactory,
        IAbstractFactory<string>,
        IAbstractFactory<string, string>,
        IAbstractFactory<string, string, string>,
        IAbstractFactory<string, string, string, string>,
        IAbstractFactory<string, string, string, string, string>
    {
        /// <summary>
        /// Creates a Oracle connection.
        /// </summary>
        /// <returns>The Oracle connection.</returns>
        public IAbstractProduct New() => new OracleConnection();

        public IAbstractProduct New(string param) => new OracleConnection(param);

        public IAbstractProduct New(string param1, string param2) => new OracleConnection(param1, param2);

        public IAbstractProduct New(string param1, string param2, string param3) => new OracleConnection(param1, param2, param3);

        public IAbstractProduct New(string param1, string param2, string param3, string param4) => new OracleConnection(param1, param2, param3, param4);

        public IAbstractProduct New(string param1, string param2, string param3, string param4, string param5) => new OracleConnection(param1, param2, param3, param4, param5);
    }
}
