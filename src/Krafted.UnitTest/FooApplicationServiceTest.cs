using System;
using Xunit;
using Krafted.IntegrationTest.FooBar.Domain;
using Krafted.IntegrationTest.FooBar.Application;
using SharedKernel.Domain;
using NSubstitute;

namespace Krafted.UnitTest
{
    [Trait(nameof(UnitTest), nameof(Foo))]
    public class FooApplicationServiceTest : IClassFixture<TestFixture>
    {
        private readonly IRepositoryAsync<Foo> _fooRepository;
        private readonly FooApplicationService _fooAppService;
        private readonly TestFixture _fixture;
        private readonly Guid _fooId = default(Guid);

        public FooApplicationServiceTest(TestFixture fixture)
        {
            _fixture = fixture;

            _fooRepository = Substitute.For<IRepositoryAsync<Foo>>();
            var foo = new Foo("O nome do foo", new DateTime(2018, 11, 16), new DateTime(2018, 11, 17));

            _fooRepository.GetByIdAsync(_fooId).Returns(foo);

            _fooAppService = new FooApplicationService(
                _fooRepository,
                fixture.UnitOfWork,
                fixture.CommandResultFactory);
        }

        [Fact]
        public void ShouldCreateFoo_WhenCommandIsValid_Valid()
        {
            var command = new CreateFooCommand
            {
                Name = "O nome do foo",
                StartDate = new DateTime(2018, 11, 16),
                EndDate = new DateTime(2018, 11, 17),
            };

            var result = _fooAppService.HandleAsync(command);

            Assert.NotNull(result);
            Assert.True(_fooAppService.Valid);
        }

        [Fact]
        public void ShouldChangeScheduleFoo_WhenCommandIsValid_Valid()
        {
            var command = new ChangeScheduleFooCommand
            {
                StartDate = new DateTime(2018, 11, 20),
                EndDate = new DateTime(2018, 11, 21),
            };

            var result = _fooAppService.HandleAsync(command);

            Assert.NotNull(result);
            Assert.True(_fooAppService.Valid);
        }
    }
}