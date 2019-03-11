using System;
using Newtonsoft.Json;

namespace Krafted.Test.Result
{
    /// <summary>
    /// Represents a dummy class for test purpose.
    /// </summary>
    public class ResponseCommandResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseCommandResult"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="success"><c>true</c> if success; otherwise, <c>false</c> if fail.</param>
        /// <param name="mensagem">The message.</param>
        public ResponseCommandResult(string id, bool success, string mensagem)
        {
            Id = new Guid(id);
            Success = success;
            Message = mensagem;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseCommandResult"/> class.
        /// </summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="mensagem">The mensagem.</param>
        public ResponseCommandResult(bool success, string mensagem)
        {
            Success = success;
            Message = mensagem;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("mensagem")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ResponseCommandResult"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c> if fail.</value>
        public bool Success { get; set; }
    }
}