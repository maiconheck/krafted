using System.Collections.Generic;

namespace Krafted.Test.Result
{
    /// <summary>
    /// Represents the <see cref="DefaultDetailedCommandResult"/> class.
    /// </summary>
    public class DefaultDetailedCommandResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DefaultDetailedCommandResult"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DefaultDetailedCommandResult" /> is failure.
        /// </summary>
        /// <value>
        /// <c>true</c> if failure; otherwise, <c>false</c>.
        /// </value>
        public bool Failure { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public List<Notification> Data { get; set; } = new List<Notification>();
    }
}