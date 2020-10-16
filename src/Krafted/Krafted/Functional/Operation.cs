namespace Krafted.Functional
{
    /// <summary>
    /// Represents an operation that can be <c>Valid</c> or <c>Invalid</c> for some reason.
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Operation"/> class.
        /// </summary>
        /// <param name="valid"><c>true</c> if valid; otherwise, <c>false</c>.</param>
        /// <param name="invalidReason">The optional message describing the reason for the invalid operation.</param>
        internal Operation(bool valid, string invalidReason = "")
        {
            Valid = valid;
            InvalidReason = invalidReason;
        }

        /// <summary>
        /// Gets a value indicating whether this operation is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if valid; otherwise, <c>false</c>.
        /// </value>
        public bool Valid { get; }

        /// <summary>
        /// Gets a value indicating whether this operation is invalid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if invalid; otherwise, <c>false</c>.
        /// </value>
        public bool Invalid => !Valid;

        /// <summary>
        /// Gets the optional message describing the reason for the invalid operation.
        /// </summary>
        /// <value>The message.</value>
        public string InvalidReason { get; }
    }
}
