using Krafted.DesignPatterns.Factories;

namespace Krafted.UnitTest.DesignPatterns.Factories.SqlServer
{
    /// <summary>
    /// Represents the ConcreteProduct [Gamma et al.] SqlConnection.
    /// </summary>
    public class SqlConnection : IAbstractProduct
    {
        public SqlConnection()
        {
        }

        public string ConnectionString { get; }

        public SqlConnection(string param1) => ConnectionString = param1;

        public SqlConnection(string param1, string param2) => ConnectionString = $"{param1} {param2}";

        public SqlConnection(string param1, string param2, string param3) => ConnectionString = $"{param1} {param2} {param3}";

        public SqlConnection(string param1, string param2, string param3, string param4) => ConnectionString = $"{param1} {param2} {param3} {param4}";

        public SqlConnection(string param1, string param2, string param3, string param4, string param5) => ConnectionString = $"{param1} {param2} {param3} {param4} {param5}";
    }
}
