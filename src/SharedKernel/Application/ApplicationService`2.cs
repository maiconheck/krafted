using System.Threading.Tasks;
using SharedKernel.Application.Commands.Result;
using SharedKernel.Domain;
using SharedKernel.Transactions;

namespace SharedKernel.Application
{
    public abstract class ApplicationService<TEntity> : ApplicationService
        where TEntity : Entity
    {
        private readonly IRepositoryAsync<TEntity> _repository;

        protected ApplicationService(
            IRepositoryAsync<TEntity> repository,
            IUnitOfWork unitOfWork,
            ICommandResultFactory commandResultFactory)
                : base(unitOfWork, commandResultFactory)
        {
            _repository = repository;
        }

        protected async Task<ICommandResult> CreateAsync(TEntity entity, object successData, string successMessage = "")
            => await DoCreateAsync(entity, successData, successMessage: successMessage);

        protected async Task<ICommandResult> CreateAsync(TEntity entity, object successData, object createData, string successMessage = "")
            => await DoCreateAsync(entity, successData, createData: createData, successMessage: successMessage);

        protected async Task<ICommandResult> UpdateAsync(TEntity entity, object successData, string successMessage = "")
            => await DoUpdateAsync(entity, successData, successMessage: successMessage);

        protected async Task<ICommandResult> UpdateAsync(TEntity entity, object successData, object updateData, string successMessage = "")
            => await DoUpdateAsync(entity, successData, updateData: updateData, successMessage: successMessage);

        protected async Task<ICommandResult> DeleteAsync(TEntity entity, string successMessage = "")
        {
            var result = CommandResultFactory.NewCommandResult(_commandResultFactory, entity, null, successMessage);

            if (!result.Success)
                return result;

            await _repository.DeleteAsync(entity).ConfigureAwait(false);
            UnitOfWork.Commit();

            return result;
        }

        private async Task<ICommandResult> DoUpdateAsync(TEntity entity, object successData, object updateData = null, string successMessage = "")
        {
            var commandResult = new ClientCommandResult(_commandResultFactory);

            if (entity == null)
                return commandResult.NewFailCommandResult("Registro não encontrado.");

            var result = CommandResultFactory.NewCommandResult(_commandResultFactory, entity, successData, successMessage);

            if (!result.Success)
                return result;

            if (updateData != null)
                await _repository.UpdateAsync(entity, updateData).ConfigureAwait(false);
            else
                await _repository.UpdateAsync(entity, updateData).ConfigureAwait(false);

            UnitOfWork.Commit();

            return result;
        }

        private async Task<ICommandResult> DoCreateAsync(TEntity entity, object successData, object createData = null, string successMessage = "")
        {
            var result = CommandResultFactory.NewCommandResult(_commandResultFactory, entity, successData, successMessage);

            if (!result.Success)
                return result;

            if (createData != null)
                await _repository.CreateAsync(entity, createData).ConfigureAwait(false);
            else
                await _repository.CreateAsync(entity).ConfigureAwait(false);

            UnitOfWork.Commit();

            return result;
        }
    }
}