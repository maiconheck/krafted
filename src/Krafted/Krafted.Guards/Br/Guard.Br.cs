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
        /// Throws an <see cref="FormatException"/> if the <c>cpf</c> is invalid,
        /// with this error message: Invalid CPF: {cpf}.
        /// <para>
        /// CPF stands for "Cadastro de Pessoa Física" in Brazil.
        /// It's used to identify an individual taxpayer in Brazil.
        /// <see href="https://pt.wikipedia.org/wiki/Cadastro_de_Pessoas_F%C3%ADsicas">See more</see>.
        /// </para>
        /// </summary>
        /// <param name="cpf">The cpf to check.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="FormatException">.</exception>
        public Guard InvalidCpf(string cpf, string message = "")
        {
            Guard.Against
                .NullOrWhiteSpace(cpf)
                .NotMatch<FormatException>(cpf, "^([0-9]{11})$", message: Texts.InvalidCpf.Format(cpf).OrFallback(message));

            if (!Br.Validator.ValidateCpf(cpf))
                throw new FormatException(Texts.InvalidCpf.Format(cpf).OrFallback(message));

            return this;
        }

        /// <summary>
        /// Throws an <see cref="FormatException"/> if the <c>cnpj</c> is invalid,
        /// with this error message: Invalid CNPJ: {cnpj}.
        /// <para>
        /// CNPJ stands for "Cadastro Nacional da Pessoa Jurídica" in Brazil.
        /// It's used to identify a legal entity and other types of legal arrangement without legal personality (such as condominiums,
        /// public agencies, funds) in Brazil.
        /// <see href="https://pt.wikipedia.org/wiki/Cadastro_Nacional_da_Pessoa_Jur%C3%ADdica">See more</see>.
        /// </para>
        /// </summary>
        /// <param name="cnpj">The cnpj to check.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="FormatException">.</exception>
        public Guard InvalidCnpj(string cnpj, string message = "")
        {
            Guard.Against
                .NullOrWhiteSpace(cnpj)
                .NotMatch<FormatException>(cnpj, "^([0-9]{14})$", message: Texts.InvalidCnpj.Format(cnpj).OrFallback(message));

            if (!Br.Validator.ValidateCnpj(cnpj))
                throw new FormatException(Texts.InvalidCnpj.Format(cnpj).OrFallback(message));

            return this;
        }
    }
}
