using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Krafted.Api
{
    /// <summary>
    /// Class ProviderStateApiFactory.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory{TEntryPoint}" />
    /// </summary>
    /// <typeparam name="TEntryPoint">The type of the t entry point.</typeparam>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory{TEntryPoint}" />
    /// <remarks>https://docs.microsoft.com/pt-br/aspnet/core/test/integration-tests?view=aspnetcore-2.1</remarks>
    public class ProviderStateApiFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint>
        where TEntryPoint : class
    {
        /// <summary>
        /// Creates a <see cref="IWebHostBuilder" /> used to set up <see cref="Microsoft.AspNetCore.TestHost.TestServer" />.
        /// </summary>
        /// <returns>A <see cref="IWebHostBuilder" /> instance.</returns>
        /// <remarks>The default implementation of this method looks for a <c>public static IWebHostBuilder CreateDefaultBuilder(string[] args)</c>
        /// method defined on the entry point of the assembly of <typeparamref name="TEntryPoint" /> and invokes it passing an empty string
        /// array as arguments.</remarks>
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