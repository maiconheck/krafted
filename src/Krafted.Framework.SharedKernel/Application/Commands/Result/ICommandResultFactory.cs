using System.Collections.Generic;
using Flunt.Notifications;

namespace Krafted.Framework.SharedKernel.Application.Commands.Result
{
    /// <summary>
    /// Abstract Factory
    /// </summary>
    public interface ICommandResultFactory
    {
        ICommandResult NewSuccessCommandResult(string message);

        ICommandResult NewSuccessCommandResult(object data, string message);

        ICommandResult NewFailCommandResult(string message);

        ICommandResult NewFailCommandResult(IEnumerable<Notification> notifications, string message);
    }
}