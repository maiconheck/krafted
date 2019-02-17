
using Krafted.Framework.Infrastructure.Transactions;
using Krafted.Framework.SharedKernel.Transactions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Krafted.Framework.Infrastructure.Connections.SqlServer
{
    public static class ConfigurationSqlServerConnection
    {
        public static IServiceCollection ConfigureSqlServerConnectionProvider<T>(
            this IServiceCollection services,
            IConfigurationSection configuration) where T : class, IConnectionProvider
        {
            if (configuration.Key.Equals("ConnectionStrings"))
            {
                services.Configure<ConnectionProviderOptions>(configuration);
            }

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IConnectionProvider, T>();

            return services;
        }
    }
}
