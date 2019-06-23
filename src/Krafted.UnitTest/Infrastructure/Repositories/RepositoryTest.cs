using NSubstitute;
using SharedKernel.Transactions;
using Xunit;

namespace Krafted.UnitTest.Infrastructure.Repositories
{
    [Trait(nameof(UnitTest), nameof(Infrastructure))]
    public class RepositoryTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RepositoryStub _repository;

        public RepositoryTest()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _repository = new RepositoryStub(_unitOfWork);
        }

        [Fact]
        public void Transaction_Call_ShouldBeReceived()
        {
            var called = _repository.Transaction;
            var received = _unitOfWork.Received().Transaction;
        }

        [Fact]
        public void Connection_Call_ShouldBeReceived()
        {
            var called = _repository.Connection;
            var received = _unitOfWork.Received().Transaction.Connection;
        }
    }
}