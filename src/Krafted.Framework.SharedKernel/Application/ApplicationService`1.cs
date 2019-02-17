using System;
using System.Threading.Tasks;
using Flunt.Notifications;
using Krafted.Framework.SharedKernel.Application.Commands.Result;
using Krafted.Framework.SharedKernel.Transactions;

namespace Krafted.Framework.SharedKernel.Application
{
    public abstract class ApplicationService : Notifiable
    {
        protected IUnitOfWork UnitOfWork { get; private set; }
        protected readonly ICommandResultFactory _commandResultFactory;

        protected ApplicationService(
            IUnitOfWork unitOfWork,
            ICommandResultFactory commandResultFactory)
        {
            UnitOfWork = unitOfWork;
            _commandResultFactory = commandResultFactory;
        }

        protected async Task<ICommandResult> SaveAsync(Action action, Notifiable model, object successData = null, string successMessage = "")
        {
            var result = CommandResultFactory.NewCommandResult(_commandResultFactory, model, successData, successMessage);

            if (!result.Success)
                return result;

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (model.Valid)
            {
                action();
                UnitOfWork.Commit(); 
            }

            return result;
        }
    }
}
