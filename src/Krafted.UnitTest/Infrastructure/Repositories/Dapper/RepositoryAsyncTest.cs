using System;
using Dapper;
using Krafted.Infrastructure.Repositories.Dapper;
using Krafted.Infrastructure.Sql;
using NSubstitute;
using SharedKernel.Domain;
using SharedKernel.Transactions;
using Xunit;

namespace Krafted.UnitTest.Infrastructure.Repositories.Dapper
{
    [Trait(nameof(UnitTest), nameof(Infrastructure))]
    public class RepositoryAsyncTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryAsync<Foo> _repository;
        private readonly ISqlBuilderFactory _factory;
        private readonly Foo _entity;

        public RepositoryAsyncTest()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _factory = Substitute.For<ISqlBuilderFactory>();

            _repository = new RepositoryAsync<Foo>(_unitOfWork, _factory);
            _entity = new Foo("The name", DateTime.Today, DateTime.Today.AddDays(1));
        }

        [Fact]
        public void GetByIdAsync_Call_ShouldBeReceived()
        {
            _repository.GetByIdAsync(Guid.NewGuid());
            _unitOfWork.Received().Transaction.Connection.QueryFirstOrDefaultAsync<Foo>(Arg.Any<string>());
        }

        [Fact]
        public void GetAllAsync_Call_ShouldBeReceived()
        {
            _repository.GetAllAsync();
            _unitOfWork.Received().Transaction.Connection.QueryAsync<Foo>(Arg.Any<string>());
        }

        [Fact]
        public void GetAllAsync_WhereConditions_ThrowsNotImplementedException()
            => Assert.ThrowsAsync<NotImplementedException>(() => _repository.GetAllAsync(string.Empty));

        [Fact]
        public void CreateAsync_Call_ShouldBeReceived()
        {
            _repository.CreateAsync(_entity);
            AssertExecuteAsyncReceived();
        }

        [Fact]
        public void UpdateAsync_Call_ShouldBeReceived()
        {
            _repository.UpdateAsync(_entity);
            AssertExecuteAsyncReceived();
        }

        [Fact]
        public void DeleteAsync_Call_ShouldBeReceived()
        {
            _repository.DeleteAsync(_entity);
            AssertExecuteAsyncReceived();
        }

        private void AssertExecuteAsyncReceived() => _unitOfWork.Received().Transaction.Connection.ExecuteAsync(Arg.Any<string>());
    }
}