using System;
using System.Diagnostics.CodeAnalysis;
using NSubstitute;
using SharedKernel.Application.Commands.Result;
using SharedKernel.Transactions;

namespace Krafted.Test
{
    /// <summary>
    /// Represents the TestFixture.
    /// xUnit implements "test class as context" pattern.
    /// See: http://xunit.github.io/docs/shared-context#constructor
    /// xUnit.net creates a new instance of the test class for every test that is run,
    /// so any code which is placed into the constructor of the test class will be run for every single test.
    /// Implements the <see cref="IDisposable" />.
    /// </summary>
    /// <seealso cref="IDisposable" />
    [ExcludeFromCodeCoverage]
    public class TestFixture : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestFixture"/> class.
        /// </summary>
        public TestFixture()
        {
            UnitOfWork = Substitute.For<IUnitOfWork>();
            CommandResultFactory = Substitute.For<ICommandResultFactory>();
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        public IUnitOfWork UnitOfWork { get; private set; }

        /// <summary>
        /// Gets the command result factory.
        /// </summary>
        /// <value>
        /// The command result factory.
        /// </value>
        public ICommandResultFactory CommandResultFactory { get; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitOfWork?.Dispose();
                UnitOfWork = null;
            }
        }
    }
}