using System.Threading.Tasks;
using Krafted.IntegrationTest.FooBar.Domain;
using SharedKernel.Application;
using SharedKernel.Application.Commands;
using SharedKernel.Application.Commands.Result;
using SharedKernel.Domain;
using SharedKernel.Transactions;

namespace Krafted.IntegrationTest.FooBar.Application
{
    public class FooApplicationService : ApplicationService<Foo>,
        ICommandHandlerAsync<CreateFooCommand>,
        ICommandHandlerAsync<ChangeScheduleFooCommand>,
        ICommandHandlerAsync<DeleteFooCommand>,
        ICommandHandlerAsync<CancelFooCommand>
    {
        private readonly IRepositoryAsync<Foo> _fooRepository;

        public FooApplicationService(
            IRepositoryAsync<Foo> fooRepository,
            IUnitOfWork unitOfWork,
            ICommandResultFactory commandResultFactory)
                : base(fooRepository, unitOfWork, commandResultFactory)
        {
            _fooRepository = fooRepository;
        }

        public Task<ICommandResult> HandleAsync(CreateFooCommand command)
        {
            var foo = new Foo(command.Name, command.StartDate, command.EndDate);
            return CreateAsync(foo, new { foo.Id, foo.Name, foo.StartDate, foo.EndDate }, "Foo criado com sucesso.");
        }

        public async Task<ICommandResult> HandleAsync(ChangeScheduleFooCommand command)
        {
            var foo = await _fooRepository.GetByIdAsync(command.Id).ConfigureAwait(false);
            foo?.ChangeSchedule(command.StartDate, command.EndDate);

            return await UpdateAsync(
                foo,
                new { foo?.Id, foo?.StartDate, foo?.EndDate, foo?.Name },
                $"Foo {foo?.Name} atualizado com sucesso.").ConfigureAwait(false);
        }

        public async Task<ICommandResult> HandleAsync(DeleteFooCommand command)
        {
            var foo = await _fooRepository.GetByIdAsync(command.Id).ConfigureAwait(false);
            return await DeleteAsync(foo, $"Foo {foo?.Name} excluido com sucesso.").ConfigureAwait(false);
        }

        public async Task<ICommandResult> HandleAsync(CancelFooCommand command)
        {
            var foo = await _fooRepository.GetByIdAsync(command.Id).ConfigureAwait(false);
            foo?.Cancel();

            return await UpdateAsync(foo, new { foo?.Id, foo?.Canceled }, $"Foo {foo?.Name} atualizado com sucesso.").ConfigureAwait(false);
        }
    }
}