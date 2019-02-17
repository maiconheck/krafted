namespace Krafted.Framework.SharedKernel.Application.Commands.Result.Default
{
    /// <summary>
    /// Concrete Product DefaultCommandResult
    /// </summary>
    public class DefaultCommandResult : ICommandResult
    {
        public DefaultCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}