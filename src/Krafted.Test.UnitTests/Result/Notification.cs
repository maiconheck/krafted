namespace Krafted.Test.UnitTest.Result
{
    /// <summary>
    /// Represents a dummy class for test purpose.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="message">The message.</param>
        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }

        /// <summary>
        /// Gets or sets the property.
        /// </summary>
        /// <value>The property.</value>
        public string Property { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
    }
}