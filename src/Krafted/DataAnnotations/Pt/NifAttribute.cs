using System;
using System.ComponentModel.DataAnnotations;

namespace Krafted.DataAnnotations.Pt
{
    /// <summary>
    /// Validates whether the specified <c>nif</c> is valid.
    /// </summary>
    /// <remarks>
    /// NIF means "Número de Identificação Fiscal", a.k.a "Número de Contribuinte", identifies a taxpayer entity in Portugal, whether it is a company or an individual.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class NifAttribute : ValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NifAttribute"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor selects a reasonable default error message for <see cref="ValidationAttribute.FormatErrorMessage" />.
        /// </remarks>
        public NifAttribute()
            : base(Texts.InvalidNif)
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

            return Guards.Pt.Validator.ValidateNif((string)value);

        }
    }
}
