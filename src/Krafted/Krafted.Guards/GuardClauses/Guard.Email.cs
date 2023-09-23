// The regular expression below was obtained from the FluentValidation lib.
//
// Source: https://github.com/FluentValidation/FluentValidation/blob/265fef0aed50183a8a48be4ffc0abd40c2ccaa2e/src/FluentValidation/Validators/EmailValidator.cs
// Retrieved in September 2020.

using System;
using System.Runtime.CompilerServices;

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
        /// Throws an <see cref="FormatException"/> if the <c>emailAddress</c> is invalid,
        /// with this error message: E-mail address invalid: {emailAddress}.
        /// </summary>
        /// <remarks>
        /// If the <c>emailAddress</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <see cref="ArgumentException"/>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <param name="emailAddress">The e-mail address to check.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="emailAddress"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="FormatException">.</exception>
        public Guard InvalidEmail(string? emailAddress, string message = "", [CallerArgumentExpression("emailAddress")] string? parameterName = null)
        {
            string resourceLocalized = Texts.InvalidEmailAddress.Format(emailAddress ?? string.Empty);
            return Validate<string?, ArgumentException>(emailAddress, _ => !Validator.ValidateEmail(emailAddress!), resourceLocalized, message, parameterName);
        }
    }
}
