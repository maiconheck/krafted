using System.Text.Json.Serialization;

namespace Krafted.Rfc.ProblemDetails.Types
{
    /// <summary>
    /// Represents a success response.
    /// </summary>
    /// <seealso cref="IResponse" />
    public class SuccessResponse : IResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessResponse"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="data">The data.</param>
        /// <param name="status">The status.</param>
        /// <param name="title">The title.</param>
        /// <param name="detail">The detail.</param>
        public SuccessResponse(
            ResponseType type,
            object data,
            int status,
            string title = "",
            string detail = "")
        {
            Type = type;
            Data = data;
            Status = status;
            Title = title;
            Detail = detail;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public object Data { get; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public int Status { get; }

        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        public string Detail { get; }

        /// <summary>
        /// Gets the response type.
        /// </summary>
        /// <value>
        /// The response type.
        /// </value>
        [JsonIgnore]
        public ResponseType Type { get; }
    }
}
