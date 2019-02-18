using System.Threading.Tasks;
using SharedKernel.Application.Commands.Result;

namespace SharedKernel.Application.Commands
{
    public interface ICommandHandlerAsync<T>
        where T : ICommand
    {
        Task<ICommandResult> HandleAsync(T command);
    }
}