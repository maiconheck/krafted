using System.Threading.Tasks;
using Krafted.Framework.IntegrationTest.FooBar.Domain;
using Krafted.Framework.SharedKernel.Application;
using Krafted.Framework.SharedKernel.Application.Commands;
using Krafted.Framework.SharedKernel.Application.Commands.Result;
using Krafted.Framework.SharedKernel.Domain;
using Krafted.Framework.SharedKernel.Transactions;

namespace Krafted.Framework.IntegrationTest.FooBar.Application
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

        public async Task<ICommandResult> HandleAsync(CreateFooCommand command)
        {
            var foo = new Foo(command.Name, command.StartDate, command.EndDate);
            return await CreateAsync( foo, new { foo.Id, foo.Name, foo.StartDate, foo.EndDate }, $"Foo criado com sucesso.");
        }

        public async Task<ICommandResult> HandleAsync(ChangeScheduleFooCommand command)
        {
            var foo = await _fooRepository.GetByIdAsync(command.Id).ConfigureAwait(false);
            foo?.ChangeSchedule(command.StartDate, command.EndDate);

            return await UpdateAsync(
                foo, 
                new { foo?.Id, foo?.StartDate, foo?.EndDate, foo?.Name },
                $"Foo {foo?.Name} atualizado com sucesso.");
        }

        public async Task<ICommandResult> HandleAsync(DeleteFooCommand command)
        {
            var foo = await _fooRepository.GetByIdAsync(command.Id);
            return await DeleteAsync(foo, $"Foo {foo?.Name} excluido com sucesso.");
        }

        public async Task<ICommandResult> HandleAsync(CancelFooCommand command)
        {
            var foo = await _fooRepository.GetByIdAsync(command.Id);
            foo?.Cancel();

            return await UpdateAsync(foo, new { foo?.Id, foo?.Canceled }, $"Foo {foo?.Name} atualizado com sucesso.");
        }
    }
}