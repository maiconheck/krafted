using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Krafted.DataAnnotations
{
    /// <summary>
    /// Specifies that at least one item is required.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class NotEmptyCollectionAttribute : ValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotEmptyCollectionAttribute"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor selects a reasonable default error message for <see cref="ValidationAttribute.FormatErrorMessage" />.
        /// </remarks>
        public NotEmptyCollectionAttribute()
            : base(Texts.NotEmptyCollection)
        {
        }

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns><c>true</c> if the specified value is valid; otherwise, <c>false</c>.</returns>
        public override bool IsValid(object value)
        {
            var list = value as IList;

            if (list is null)
                return false;

            return list.Count > 0;
        }
    }
}
