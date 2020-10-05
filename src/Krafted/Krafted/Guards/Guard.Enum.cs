using System;

namespace Krafted.Guards
{
    /// <summary>
    /// Provides guard clauses to validate method arguments, in order to enforce defensive programming practice.
    /// <see href="https://en.wikipedia.org/wiki/Defensive_programming">See defensive programming</see>.
    /// <see href="http://wiki.c2.com/?GuardClause">See guard clauses</see>.
    /// </summary>
    public partial class Guard
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the specified <c>value</c> not exists in
        /// the specified <c>TEnum</c> enumeration, with this error message: The {value} not exists in the {TEnum}.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard NotExists<TEnum>(int value) where TEnum : Enum
        {
            var type = typeof(TEnum);

            if (!Enum.IsDefined(type, value))
                throw new ArgumentException(Texts.ValueNotExistsIn.Format(value, type.Name));

            return this;
        }
    }
}
