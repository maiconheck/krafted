using Krafted.Framework.SharedKernel.Application.Commands.Result;

namespace Krafted.Framework.SharedKernel.Application.Commands
{
    public interface ICommandHandler<T>
        where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}