using System;
using NSubstitute;
using SharedKernel.Application.Commands.Result;
using SharedKernel.Transactions;

namespace Krafted.UnitTest
{
    /// <summary>
    /// xUnit implements "test class as context" pattern.
    /// See: http://xunit.github.io/docs/shared-context#constructor
    /// "xUnit.net creates a new instance of the test class for every test that is run,
    /// so any code which is placed into the constructor of the test class will be run for every single test.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class TestFixture : IDisposable
    {
        public TestFixture()
        {
            UnitOfWork = Substitute.For<IUnitOfWork>();
            CommandResultFactory = Substitute.For<ICommandResultFactory>();
        }

        public IUnitOfWork UnitOfWork { get; private set; }

        public ICommandResultFactory CommandResultFactory { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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