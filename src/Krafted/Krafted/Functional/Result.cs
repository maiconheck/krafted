namespace Krafted.Functional
{
    /// <summary>
    /// Provides factory methods for the <see cref="Maybe{T}"/> and <see cref="Maybe{Operation}"/>, according operation result, that is, <c>Success</c> or <c>Failure</c>.
    /// </summary>
    public static class Result
    {
        /// <summary>
        /// Returns a success operation, that is, <see cref="Operation.Valid"/> is true. See <see cref="Operation"/>.
        /// </summary>
        /// <returns>A valid operation.</returns>
        public static Maybe<Operation> Success()
        {
            var operation = new Operation(true);
            return new Maybe<Operation>(operation);
        }

        /// <summary>
        /// Returns a success operation, that is, <see cref="Operation.Valid"/> is true, with an associated <c>value</c>. See <see cref="Operation"/>.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>A success operation with an associated <c>value</c>.</returns>
        public static Maybe<Operation<T>> Success<T>(T value)
        {
            var operation = new Operation<T>(value, true);
            return new Maybe<Operation<T>>(operation);
        }

        /// <summary>
        /// Returns a failure operation, that is, <see cref="Operation.Valid"/> is false. See <see cref="Operation"/>.
        /// </summary>
        /// <param name="invalidReason">The optional message describing the reason for the invalid operation.</param>
        /// <returns>A failure operation.</returns>
        public static Maybe<Operation> Failure(string invalidReason)
        {
            var operation = new Operation(false, invalidReason);
            return new Maybe<Operation>(operation);
        }

        /// <summary>
        /// Returns a failure operation, that is, <see cref="Operation.Valid"/> is false, with an associated <c>value</c>. See <see cref="Operation"/>.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="invalidReason">The optional message describing the reason for the invalid operation.</param>
        /// <returns>A failure operation with an associated <c>value</c>.</returns>
        public static Maybe<Operation<T>> Failure<T>(T value, string invalidReason)
        {
            var operation = new Operation<T>(value, false, invalidReason);
            return new Maybe<Operation<T>>(operation);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Maybe{T}"/> class.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>A new instance of the <see cref="Maybe{T}"/> class.</returns>
        public static Maybe<T> Maybe<T>(T value) => new Maybe<T>(value);
    }
}
