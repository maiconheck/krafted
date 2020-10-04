using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Krafted.DataAnnotations
{
    /// <summary>
    /// Specifies that the value is at minimum one (that is, positive).
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class MinOneAttribute : ValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinOneAttribute"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor selects a reasonable default error message for <see cref="ValidationAttribute.FormatErrorMessage" />.
        /// </remarks>
        public MinOneAttribute()
            : base(Texts.MinOne)
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

            var number = Convert.ToInt64(value, CultureInfo.InvariantCulture);

            return number > 0;
        }
    }
}
