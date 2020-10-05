using System;
using System.ComponentModel.DataAnnotations;

namespace Krafted.DataAnnotations
{
    /// <summary>
    /// Validates whether the specified <c>email address</c> is valid using regular expression.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class EmailAddressRegexAttribute : ValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddressRegexAttribute"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor selects a reasonable default error message for <see cref="ValidationAttribute.FormatErrorMessage" />.
        /// </remarks>
        public EmailAddressRegexAttribute()
            : base(Texts.InvalidEmailAddress)
        {
        }

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns><c>true</c> if the specified value is valid; otherwise, <c>false</c>.</returns>
        public override bool IsValid(object value)
        {
            if (value is null)
                return false;

            return Guards.Validator.ValidateEmail((string)value);
        }
    }
}
