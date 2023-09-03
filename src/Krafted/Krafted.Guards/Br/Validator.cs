// Common validation methods for Brazil.
//
// The CPF and CNPJ validation algorithms is based on the Macoratti's implementation:
// Source: https://www.macoratti.net/11/09/c_val1.htm
// Retrieved in August 2023.

using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Krafted.ValueObjects")]

namespace Krafted.Guards.Br
{
    /// <summary>
    /// Provides common validation methods for Brazil.
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Validates whether the specified <c>cpf</c> is valid.
        /// <para>
        /// CPF stands for "Cadastro de Pessoa Física" in Brazil.
        /// It's used to identify an individual taxpayer in Brazil.
        /// <see href="https://pt.wikipedia.org/wiki/Cadastro_de_Pessoas_F%C3%ADsicas">See more</see>.
        /// </para>
        /// </summary>
        /// <param name="cpf">The <c>cpf</c> to validate.</param>
        /// <returns><c>true</c> if the specified <c>cpf</c> is valid; otherwise, <c>false</c>.</returns>
        public static bool ValidateCpf(string cpf)
        {
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCpf[i].ToString(CultureInfo.InvariantCulture)) * multiplier1[i];
            }

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString(CultureInfo.InvariantCulture);
            tempCpf = tempCpf + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(tempCpf[i].ToString(CultureInfo.InvariantCulture)) * multiplier2[i];
            }

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString(CultureInfo.InvariantCulture);

            return cpf.EndsWith(digit);
        }

        /// <summary>
        /// Validates whether the specified <c>cnpj</c> is valid.
        /// <para>
        /// CNPJ stands for "Cadastro Nacional da Pessoa Jurídica" in Brazil.
        /// It's used to identify a legal entity and other types of legal arrangement without legal personality (such as condominiums,
        /// public agencies, funds) in Brazil.
        /// <see href="https://pt.wikipedia.org/wiki/Cadastro_Nacional_da_Pessoa_Jur%C3%ADdica">See more</see>.
        /// </para>
        /// </summary>
        /// <param name="cnpj">The <c>cnpj</c> to validate.</param>
        /// <returns><c>true</c> if the specified <c>cnpj</c> is valid; otherwise, <c>false</c>.</returns>
        public static bool ValidateCnpj(string cnpj)
        {
            int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum;
            int rest;
            string digit;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);
            sum = 0;

            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(tempCnpj[i].ToString(CultureInfo.InvariantCulture)) * multiplier1[i];
            }

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString(CultureInfo.InvariantCulture);
            tempCnpj = tempCnpj + digit;
            sum = 0;

            for (int i = 0; i < 13; i++)
            {
                sum += int.Parse(tempCnpj[i].ToString(CultureInfo.InvariantCulture)) * multiplier2[i];
            }

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString(CultureInfo.InvariantCulture);

            return cnpj.EndsWith(digit);
        }
    }
}
