using System.Collections.Generic;

namespace Krafted.Test.UnitTest.Result
{
    /// <summary>
    /// Represents a dummy class for test purpose.
    /// </summary>
    public class NotificationResponseCommandResult
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public IEnumerable<Notification> Dados { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public int Codigo { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Mensagem { get; set; }
    }
}