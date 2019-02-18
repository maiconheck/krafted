namespace SharedKernel.Application.Commands.Result
{
    /// <summary>
    /// Abstract Product
    /// </summary>
    public interface ICommandResult
    {
        bool Success { get; }

        string Message { get; }
    }
}