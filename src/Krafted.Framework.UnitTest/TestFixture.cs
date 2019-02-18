using System;
using NSubstitute;
using Krafted.Framework.SharedKernel.Application.Commands.Result;
using Krafted.Framework.SharedKernel.Transactions;

namespace Krafted.Framework.UnitTest
{
    /// <summary>
    /// xUnit implements "test class as context" pattern.
    ///
    /// See: http://xunit.github.io/docs/shared-context#constructor
    /// "xUnit.net creates a new instance of the test class for every test that is run,
    /// so any code which is placed into the constructor of the test class will be run for every single test."
    /// </summary>
    public class TestFixture : IDisposable
    {
        public TestFixture()
        {
            UnitOfWork = Substitute.For<IUnitOfWork>();
            CommandResultFactory = Substitute.For<ICommandResultFactory>();
        }

        public IUnitOfWork UnitOfWork { get; }

        public ICommandResultFactory CommandResultFactory { get; }

        public void Dispose() => UnitOfWork.Dispose();
    }
}