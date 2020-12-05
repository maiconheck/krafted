namespace Krafted.Rfc.ProblemDetails.Abstractions
{
    /// <summary>
    /// Represents a response as result from the handler.
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// Gets the response type.
        /// </summary>
        /// <value>
        /// The response type.
        /// </value>
        ResponseType Type { get; }
    }
}
