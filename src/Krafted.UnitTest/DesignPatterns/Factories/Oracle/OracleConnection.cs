using Krafted.DesignPatterns.Factories;

namespace Krafted.UnitTest.DesignPatterns.Factories.Oracle
{
    /// <summary>
    /// Represents the ConcreteProduct [Gamma et al.] OracleConnection.
    /// </summary>
    public class OracleConnection : IAbstractProduct
    {
        public OracleConnection()
        {
        }

        public OracleConnection(string param1) => ConnectionString = param1;

        public OracleConnection(string param1, string param2) => ConnectionString = $"{param1} {param2}";

        public OracleConnection(string param1, string param2, string param3) => ConnectionString = $"{param1} {param2} {param3}";

        public OracleConnection(string param1, string param2, string param3, string param4) => ConnectionString = $"{param1} {param2} {param3} {param4}";

        public OracleConnection(string param1, string param2, string param3, string param4, string param5) => ConnectionString = $"{param1} {param2} {param3} {param4} {param5}";

        public string ConnectionString { get; }
    }
}
