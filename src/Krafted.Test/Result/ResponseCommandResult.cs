using System;
using System.Collections.Generic;

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
        /// <param name="success"><c>true</c> if success; otherwise, <c>false</c> if fail.</param>
        /// <param name="message">The message.</param>
        public ResponseCommandResult(bool success, string message)
        {
            ExceptionHelper.ThrowIfAnyNull(() => success, () => message);

            Success = success;
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseCommandResult"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="success"><c>true</c> if success; otherwise, <c>false</c> if fail.</param>
        /// <param name="message">The message.</param>
        public ResponseCommandResult(string id, bool success, string message)
        {
            ExceptionHelper.ThrowIfAnyNull(() => id, () => success, () => message);

            Id = Guid.Parse(id);
            Success = success;
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseCommandResult"/> class.
        /// </summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="message">The mensagem.</param>
        /// <param name="data">The data.</param>
        public ResponseCommandResult(bool success, string message, List<Notification> data)
        {
            ExceptionHelper.ThrowIfAnyNull(() => success, () => message, () => data);

            Success = success;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ResponseCommandResult"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c> if fail.</value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ResponseCommandResult" /> is failure.
        /// </summary>
        /// <value>
        /// <c>true</c> if failure; otherwise, <c>false</c>.
        /// </value>
        public bool Failure => !Success;

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public List<Notification> Data { get; set; } = new List<Notification>();
    }
}