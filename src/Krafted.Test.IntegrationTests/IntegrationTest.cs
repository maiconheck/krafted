using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace Krafted.Test.IntegrationTests
{
    /// <summary>
    /// Represents the IntegrationTest base class.
    /// </summary>
    /// <typeparam name="TEntryPoint">The type of the entry point.</typeparam>
    [ExcludeFromCodeCoverage]
    public abstract class IntegrationTest<TEntryPoint>
        where TEntryPoint : class
    {
        private readonly ProviderStateApiFactory<TEntryPoint> _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTest{TEntryPoint}"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="endPoint">The end point.</param>
        protected IntegrationTest(ProviderStateApiFactory<TEntryPoint> factory, string endPoint)
        {
            GuardAgainst.Null(factory, nameof(factory));
            GuardAgainst.NullOrWhiteSpace(endPoint, nameof(endPoint));

            _factory = factory;
            Client = _factory.CreateClient();
            EndPoint = endPoint;
        }

        /// <summary>
        /// Gets the end point.
        /// </summary>
        /// <value>The end point.</value>
        public string EndPoint { get; }

        /// <summary>
        /// Gets the <see cref="HttpClient"/>.
        /// </summary>
        /// <value>The <see cref="HttpClient"/>.</value>
        protected HttpClient Client { get; }
    }
}
