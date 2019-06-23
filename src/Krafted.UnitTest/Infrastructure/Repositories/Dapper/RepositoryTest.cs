using System;
using Dapper;
using Krafted.Infrastructure.Repositories.Dapper;
using Krafted.Infrastructure.Sql;
using Krafted.IntegrationTest.FooBar.Domain;
using NSubstitute;
using SharedKernel.Domain;
using SharedKernel.Transactions;
using Xunit;

namespace Krafted.UnitTest.Infrastructure.Repositories.Dapper
{
    [Trait(nameof(UnitTest), nameof(Infrastructure))]
    public class RepositoryTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Foo> _repository;
        private readonly ISqlBuilderFactory _factory;
        private readonly Foo _entity;

        public RepositoryTest()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _factory = Substitute.For<ISqlBuilderFactory>();

            _repository = new Repository<Foo>(_unitOfWork, _factory);
            _entity = new Foo("The name", DateTime.Today, DateTime.Today.AddDays(1));
        }

        [Fact]
        public void GetById_Call_ShouldBeReceived()
        {
            _repository.GetById(Guid.NewGuid());
            _unitOfWork.Received().Transaction.Connection.QueryFirstOrDefault<Foo>(Arg.Any<string>());
        }

        [Fact]
        public void Create_Call_ShouldBeReceived()
        {
            _repository.Create(_entity);
            AssertExecuteReceived();
        }

        [Fact]
        public void Update_Call_ShouldBeReceived()
        {
            _repository.Update(_entity);
            AssertExecuteReceived();
        }

        [Fact]
        public void Delete_Call_ShouldBeReceived()
        {
            _repository.Delete(_entity);
            AssertExecuteReceived();
        }

        private void AssertExecuteReceived() => _unitOfWork.Received().Transaction.Connection.Execute(Arg.Any<string>());
    }
}