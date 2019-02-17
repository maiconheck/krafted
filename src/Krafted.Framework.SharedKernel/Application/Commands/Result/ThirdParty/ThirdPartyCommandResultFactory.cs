using System.Collections.Generic;
using Flunt.Notifications;

namespace Krafted.Framework.SharedKernel.Application.Commands.Result.ThirdParty
{
    /// <summary>
    /// ConcreteFactory ThirdParty
    /// </summary>
    public class ThirdPartyCommandResultFactory : ICommandResultFactory
    {
        private const string successMesage = "[nome do serviço] executado com sucesso";

        public ICommandResult NewSuccessCommandResult(string message = successMesage)
            => new ThirdPartyCommandResult(true, message);

        public ICommandResult NewSuccessCommandResult(object data, string message = successMesage)
            => new ThirdPartyDetailedCommandResult(true, message, data);

        public ICommandResult NewFailCommandResult(string message) => new ThirdPartyCommandResult(false, message);

        public ICommandResult NewFailCommandResult(IEnumerable<Notification> notifications, string message)
                => new ThirdPartyDetailedCommandResult(false, message, notifications);
    }
}