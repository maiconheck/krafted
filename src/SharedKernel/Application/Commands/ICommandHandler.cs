using SharedKernel.Application.Commands.Result;

namespace SharedKernel.Application.Commands
{
    public interface ICommandHandler<T>
        where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}