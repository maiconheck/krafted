namespace Krafted.Functional
{
    /// <summary>
    /// Provides factory methods for the <see cref="Maybe{T}"/> and <see cref="Maybe{Operation}"/>, according operation result, that is, <c>Success</c> or <c>Failure</c>.
    /// </summary>
    public static class Result
    {
        /// <summary>
        /// Returns a valid operation, that is, <see cref="Operation.Valid"/> is true. See <see cref="Operation"/>.
        /// </summary>
        /// <returns>A valid operation.</returns>
        public static Maybe<Operation> Success()
        {
            var operation = new Operation(true);
            return new Maybe<Operation>(operation);
        }

        /// <summary>
        /// Returns a invalid operation, that is, <see cref="Operation.Valid"/> is false. See <see cref="Operation"/>.
        /// </summary>
        /// <param name="invalidReason">The optional message describing the reason for the invalid operation.</param>
        /// <returns>A invalid operation.</returns>
        public static Maybe<Operation> Failure(string invalidReason)
        {
            var operation = new Operation(false, invalidReason);
            return new Maybe<Operation>(operation);
        }

        /// <summary>
        /// Returns a valid operation with some value.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>A valid operation with some value.</returns>
        public static Maybe<T> Success<T>(T value) => new Maybe<T>(value);

        /// <summary>
        /// Returns a invalid operation with no value.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <returns>A invalid operation with no value.</returns>
        public static Maybe<T> Failure<T>() => new Maybe<T>();
    }
}
