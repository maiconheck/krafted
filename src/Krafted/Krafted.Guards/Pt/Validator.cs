using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Krafted.ValueObjects")]

namespace Krafted.Guards.Pt
{
    /// <summary>
    /// Provides common validation methods for Portugal.
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Validates whether the specified <c>nif</c> is valid.
        /// </summary>
        /// <remarks>
        /// NIF means "Número de Identificação Fiscal", a.k.a "Número de Contribuinte", identifies a taxpayer entity in Portugal, whether it is a company or an individual.
        /// </remarks>
        /// <param name="nif">The <c>nif</c> to validate.</param>
        /// <returns><c>true</c> if the specified <c>nif</c> is valid; otherwise, <c>false</c>.</returns>
        public static bool ValidateNif(string nif)
        {
            if (string.IsNullOrWhiteSpace(nif))
            {
                return false;
            }

            nif = nif.Trim();

            var isNumeric = int.TryParse(nif, out int n);

            // Is numeric and is length 9.
            if (!isNumeric || nif.Length != 9)
            {
                return false;
            }

            // The first digit must be 1, 2, 3, 5, 6, 7, 8 or 9.
            int firstDigit = GetDigit(nif[0]);
            var firstDigitsAllowed = new int[] { 1, 2, 3, 5, 6, 7, 8, 9 };

            if (!firstDigitsAllowed.Contains(firstDigit))
            {
                return false;
            }

            // Calculates the check digit.
            int checkDigit = 0;

            for (int i = 0; i < 8; i++)
            {
                checkDigit += GetDigit(nif[i]) * (10 - i - 1);
            }

            checkDigit = 11 - (checkDigit % 11);

            // If it gives 10 then the check digit must be 0.
            if (checkDigit >= 10)
            {
                checkDigit = 0;
            }

            // Compare with the last digit.
            return checkDigit == GetDigit(nif[8]);
        }

        private static int GetDigit(char digit) => int.Parse(digit.ToString(), CultureInfo.InvariantCulture);
    }
}
