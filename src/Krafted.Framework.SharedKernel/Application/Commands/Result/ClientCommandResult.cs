using System.Collections.Generic;
using Flunt.Notifications;

namespace Krafted.Framework.SharedKernel.Application.Commands.Result
{
    /// <summary>
    /// Client
    /// </summary>
    public sealed class ClientCommandResult
    {
        private readonly ICommandResultFactory _factory;

        public ClientCommandResult(ICommandResultFactory factory)
        {
            _factory = factory;
        }

        public ICommandResult NewSuccessCommandResult(string message = "")
            => _factory.NewSuccessCommandResult(message);

        public ICommandResult NewSuccessCommandResult(object data, string message = "")
            => _factory.NewSuccessCommandResult(data, message);

        public ICommandResult NewFailCommandResult(string message = "")
            => _factory.NewFailCommandResult(message);

        public ICommandResult NewFailCommandResult(IEnumerable<Notification> notifications, string message = "")
            => _factory.NewFailCommandResult(notifications, message);
    }
}