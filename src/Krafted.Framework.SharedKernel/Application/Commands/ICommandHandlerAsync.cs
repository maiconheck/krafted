using System.Threading.Tasks;
using Krafted.Framework.SharedKernel.Application.Commands.Result;

namespace Krafted.Framework.SharedKernel.Application.Commands
{
    public interface ICommandHandlerAsync<T>
    	where T : ICommand
    {
        Task<ICommandResult> HandleAsync(T command);
    }
}