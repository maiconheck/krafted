using Krafted.DesignPatterns.Factories;

namespace Krafted.UnitTest.DesignPatterns.Factories.SqlServer
{
    /// <summary>
    /// Represents the ConcreteFactory [Gamma et al.] SqlServerConnectionFactory.
    /// </summary>
    public class SqlServerConnectionFactory :
        IAbstractFactory,
        IAbstractFactory<string>,
        IAbstractFactory<string, string>,
        IAbstractFactory<string, string, string>,
        IAbstractFactory<string, string, string, string, string>
    {
        /// <summary>
        /// Creates a SQL Server connection.
        /// </summary>
        /// <returns>The SQL Server connection.</returns>
        public IAbstractProduct New() => new SqlConnection();

        public IAbstractProduct New(string param1) => new SqlConnection(param1);

        public IAbstractProduct New(string param1, string param2) => new SqlConnection(param1, param2);

        public IAbstractProduct New(string param1, string param2, string param3) => new SqlConnection(param1, param2, param3);

        public IAbstractProduct New(string param1, string param2, string param3, string param4, string param5) => new SqlConnection(param1, param2, param3, param4, param5);
    }
}