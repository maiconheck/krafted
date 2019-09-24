using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Krafted.Api
{
    /// <summary>
    /// Factory for bootstrapping an application in memory for functional end to end tests.
    /// Implements the <see cref="WebApplicationFactory{TEntryPoint}" />.
    /// </summary>
    /// <typeparam name="TEntryPoint">A type in the entry point assembly of the application. Typically the Startup or Program classes can be used.</typeparam>
    /// <seealso cref="WebApplicationFactory{TEntryPoint}" />
    /// <remarks>https://docs.microsoft.com/pt-br/aspnet/core/test/integration-tests?view=aspnetcore-2.1.</remarks>
    [ExcludeFromCodeCoverage]
    public class ProviderStateApiFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint>
        where TEntryPoint : class
    {
        /// <summary>
        /// Creates a <see cref="IWebHostBuilder" /> used to set up <see cref="TestServer" />.
        /// </summary>
        /// <returns>A <see cref="IWebHostBuilder" /> instance.</returns>
        /// <remarks>The default implementation of this method looks for a <c>public static IWebHostBuilder CreateDefaultBuilder(string[] args)</c>
        /// method defined on the entry point of the assembly of <typeparamref name="TEntryPoint" /> and invokes it passing an empty string
        /// array as arguments.
        /// </remarks>
        protected override IWebHostBuilder CreateWebHostBuilder()
            => WebHost.CreateDefaultBuilder().UseStartup<TEntryPoint>();

        /// <summary>
        /// Gives a fixture an opportunity to configure the application before it gets built.
        /// </summary>
        /// <param name="builder">The <see cref="IWebHostBuilder" /> for the application.</param>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseContentRoot(".");
            base.ConfigureWebHost(builder);
        }
    }
}