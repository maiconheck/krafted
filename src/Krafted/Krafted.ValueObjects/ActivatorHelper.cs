using System;

namespace Krafted.ValueObjects
{
    /// <summary>
    /// When using Entity Framework with Lazy Loading, provides a helper method to bypass the Guard Clauses via reflection, during the Value Object materialization.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Because of lazy loading, when EF starts to materialize a Value Object via their public constructor, the value of the parameter is the default value of their type (in this case, null).
    /// Consequently, if that Value Object contains a Guard Clause in their public constructor, to Guard Against the default value, an ArgumentNullException would be thrown.
    /// For example, this would happen if the follow Value Object was mapped without the <c>ActivatorHelper.CreateInstance()</c>:
    /// <code>
    ///     public sealed class Name : ValueObject{string}
    ///     {
    ///         public Name(string value)
    ///         {
    ///             Guard.Against
    ///                .NullOrWhiteSpace(value, nameof(value)) // An exception would be thrown here.
    ///                .Length(2, 60, value, nameof(value));   // An exception would be thrown here.
    ///
    ///             Value = value;
    ///         }
    ///         ...
    ///     }
    /// </code>
    /// </para>
    /// <para>
    /// The CreateInstance method checks if the value is null or empty, and if it is, it creates the instance through the private constructor via reflection,
    /// to bypass the Guard Clauses, thus avoiding an exception.
    /// Otherwise, it create the instance through the public constructor.
    /// </para>
    /// <para>The value will only be null when the EF does the mapping and starts to materialize the entity,
    /// because at that time the value has not yet been loaded.
    /// </para>
    /// </remarks>
    public static class ActivatorHelper
    {
        /// <summary>
        /// Creates a new instance of a Value Object for EF mapping when using Entity Framework with Lazy Loading.
        /// <para>
        /// This method checks if the value is null or empty, and if it is, it creates the instance through the private constructor via reflection,
        /// to bypass the Guard Clauses, thus avoiding an exception.
        /// Otherwise, it create the instance through the public constructor.
        /// </para>
        /// <para>The value will only be null when the EF does the mapping and starts to materialize the entity,
        /// because at that time the value has not yet been loaded.
        /// </para>
        /// </summary>
        /// <typeparam name="TValueObject">The type of the Value Object.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>A new instance of the Value Object.</returns>
        public static TValueObject CreateInstance<TValueObject>(string value)
        {
            var type = typeof(TValueObject);

            return !string.IsNullOrEmpty(value)
                ? (TValueObject)Activator.CreateInstance(type, value)! // public constructor
                : (TValueObject)Activator.CreateInstance(type, nonPublic: true)!; // private constructor
        }

        /// <summary>
        /// Creates a new instance of a Value Object for EF mapping when using Entity Framework with Lazy Loading.
        /// <para>
        /// This method checks if the value is the DateTime default, and if it is, it creates the instance through the private constructor via reflection,
        /// to bypass the Guard Clauses, thus avoiding an exception.
        /// Otherwise, it create the instance through the public constructor.
        /// </para>
        /// <para>The value will only be the DateTime default when the EF does the mapping and starts to materialize the entity,
        /// because at that time the value has not yet been loaded.
        /// </para>
        /// </summary>
        /// <typeparam name="TValueObject">The type of the Value Object.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>A new instance of the Value Object.</returns>
        public static TValueObject CreateInstance<TValueObject>(DateTime value)
        {
            var type = typeof(TValueObject);

            return value != default
                ? (TValueObject)Activator.CreateInstance(type, value)! // public constructor
                : (TValueObject)Activator.CreateInstance(type, nonPublic: true)!; // private constructor
        }
    }
}
