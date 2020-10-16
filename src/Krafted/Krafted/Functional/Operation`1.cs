using System;

namespace Krafted.Functional
{
    /// <inheritdoc cref="Operation"/>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class Operation<T> : Operation
    {
        /// <inheritdoc cref="Operation(bool, string)"/>
        internal Operation(T value, bool valid, string invalidReason = "")
            : base(valid, invalidReason)
        {
            OperationValue = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="NullReferenceException">Occurs if the value is null.</exception>
        public T OperationValue { get; }
    }
}
