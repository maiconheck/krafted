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
        /// Throws an <see cref="FormatException"/> if the <c>nif</c> is invalid,
        /// with this error message: Invalid NIF: {nif}.
        /// <para>
        /// NIF stands for "Número de Identificação Fiscal" in Portugal.
        /// It's used to identify an individual or legal entity taxpayer in Portugal.
        /// <see href="https://pt.wikipedia.org/wiki/N%C3%BAmero_de_identifica%C3%A7%C3%A3o_fiscal">See more</see>.
        /// </para>
        /// </summary>
        /// <remarks>
        /// If the <c>nif</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <see cref="FormatException"/>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <param name="nif">The nif to check.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="FormatException">.</exception>
        public Guard InvalidNif(string? nif, string message = "")
            => Validate<string?, FormatException>(nif, _ => !Pt.Validator.ValidateNif(nif!), Texts.InvalidNif.Format(nif ?? string.Empty), message, nameof(nif));
    }
}
