using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Krafted.DataAnnotations
{
    /// <summary>
    /// Provides a helper class for tests, that can be used to validate objects, properties, and
    /// methods when it is included in their associated System.ComponentModel.DataAnnotations.ValidationAttribute
    /// attributes.
    /// </summary>
    public static class ModelValidator
    {
        /// <summary>
        /// Determines whether the specified object is valid using the validation context,
        /// validation results collection, and a value that specifies whether to validate all properties.
        /// </summary>
        /// <param name="model">The model to validate.</param>
        /// <returns><c>true</c> if the model validates; otherwise, <c>false</c> with validation results.</returns>
        public static (bool isValid, List<ValidationResult> validationResults) Validate(object model)
        {
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            var result = Validator.TryValidateObject(model, context, results, true);
            return (result, results);
        }
    }
}
