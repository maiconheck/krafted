namespace Krafted.DesignPatterns.Notifications
{
    /// <summary>
    /// Represents a notification message.
    /// </summary>
    public sealed class Notification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="message">The message.</param>
        /// <param name="localized"><c>true</c> if localized; otherwise, <c>false</c>.</param>
        public Notification(string key, string message, bool localized)
        {
            Key = key;
            Message = message;
            Localized = localized;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; }

        /// <summary>
        /// Gets or sets the notification message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Notification"/> is localized.
        /// </summary>
        /// <value>
        ///   <c>true</c> if localized; otherwise, <c>false</c>.
        /// </value>
        public bool Localized { get; }
    }
}
