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
        /// </summary>
        /// <remarks>
        /// NIF means "Número de Identificação Fiscal", a.k.a "Número de Contribuinte", identifies a taxpayer entity in Portugal, whether it is a company or an individual.
        /// </remarks>
        /// <param name="nif">The nif to check.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="FormatException">.</exception>
        public Guard InvalidNif(string nif)
        {
            Guard.Against.NullOrWhiteSpace(nif, nameof(nif));

            if (!Pt.Validator.ValidateNif(nif))
                throw new FormatException(Texts.InvalidNif.Format(nif));

            return this;
        }
    }
}
