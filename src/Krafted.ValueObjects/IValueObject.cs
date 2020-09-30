namespace Krafted.ValueObjects
{
    /// <summary>
    /// Defines a contract to the value objects.
    /// </summary>
    public interface IValueObject<T>
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        T Value { get; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        string ToString();
    }
}
