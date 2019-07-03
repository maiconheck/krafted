using System;
using System.Threading.Tasks;
using Krafted.IntegrationTest.FooBar.Application;
using Krafted.IntegrationTest.FooBar.Domain;
using Krafted.Test;
using NSubstitute;
using SharedKernel.Application.Commands.Result;
using SharedKernel.Domain;
using Xunit;

namespace Krafted.IntegrationTest.FooBar
{
    [Trait(nameof(IntegrationTest), nameof(Foo))]
    public class FooApplicationServiceTest : IClassFixture<TestFixture>
    {
        private readonly IRepositoryAsync<Foo> _fooRepository;
        private readonly FooApplicationService _fooAppService;
        private readonly TestFixture _fixture;

        public FooApplicationServiceTest(TestFixture fixture)
        {
            _fixture = fixture;

            _fooRepository = Substitute.For<IRepositoryAsync<Foo>>();
            var foo = new Foo("O nome do foo", new DateTime(2018, 11, 16), new DateTime(2018, 11, 17));

            _fooRepository.GetByIdAsync(Guid.NewGuid()).Returns(foo);

            _fooAppService = new FooApplicationService(_fooRepository, fixture.UnitOfWork, fixture.CommandResultFactory);
        }

        [Fact]
        public void ShouldCreateFoo_WhenCommandIsValid_Valid()
        {
            var command = new CreateFooCommand
            {
                Name = "O nome do foo",
                StartDate = new DateTime(2018, 11, 16),
                EndDate = new DateTime(2018, 11, 17)
            };

            Task<ICommandResult> result = _fooAppService.HandleAsync(command);

            Assert.NotNull(result);
            Assert.True(_fooAppService.Valid);
        }

        [Fact]
        public void ShouldChangeScheduleFoo_WhenCommandIsValid_Valid()
        {
            var command = new ChangeScheduleFooCommand
            {
                StartDate = new DateTime(2018, 11, 20),
                EndDate = new DateTime(2018, 11, 21)
            };

            Task<ICommandResult> result = _fooAppService.HandleAsync(command);

            Assert.NotNull(result);
            Assert.True(_fooAppService.Valid);
        }
    }
}