using Flunt.Notifications;

namespace Krafted.Framework.SharedKernel.Application.Commands.Result
{
    /// <summary>
    /// Factory Method
    /// </summary>
    public static class CommandResultFactory
    {
        public static ICommandResult NewCommandResult(
            ICommandResultFactory commandResultFactory,
            Notifiable model,
            object successData = null,
            string successMessage = "")
        {
            var commandResult = new ClientCommandResult(commandResultFactory);

            if (model == null)
                return commandResult.NewFailCommandResult("Registro não encontrado.");

            if (model.Invalid)
                return commandResult.NewFailCommandResult(model.Notifications, "Falha ao criar o registro. Verifique as mensagens de erro.");

            return (successData == null)
                ? commandResult.NewSuccessCommandResult(successMessage)
                : commandResult.NewSuccessCommandResult(successData, successMessage);
        }
    }
}