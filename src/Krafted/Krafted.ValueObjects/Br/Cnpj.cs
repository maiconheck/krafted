using System.Diagnostics.CodeAnalysis;
using Krafted.Guards;

namespace Krafted.ValueObjects.Br
{
    /// <summary>
    /// Represents a Brazilian legal entity and other types of legal arrangement value object.
    /// <para>
    /// CNPJ stands for "Cadastro Nacional da Pessoa Jurídica" in Brazil.
    /// It's used to identify a legal entity and other types of legal arrangement without legal personality (such as condominiums,
    /// public agencies, funds) in Brazil.
    /// <see href="https://pt.wikipedia.org/wiki/Cadastro_Nacional_da_Pessoa_Jur%C3%ADdica">See more</see>.
    /// </para>
    /// </summary>
    public class Cnpj : ValueObject<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cnpj"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Cnpj(string value)
        {
            Guard.Against.InvalidCnpj(value);
            Value = value;
        }

        // Required for the ORM.
        [ExcludeFromCodeCoverage]
        private Cnpj()
        {
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="Cnpj"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Cnpj(string value) => new Cnpj(value);

        /// <summary>
        /// Initializes a new instance of the <see cref="Cnpj"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A new instance of the <see cref="Cnpj"/> class.</returns>
        public static Cnpj NewCnpj(string value) => new Cnpj(value);

        /// <summary>
        /// Returns the string representation of the CNPJ <c>Value</c>.
        /// <para>
        /// If the <c>masked</c> argument is <c>true</c>, the <c>Value</c> is masked; otherwise, the <c>Value</c> is unmasked.
        /// </para>
        /// </summary>
        /// <param name="masked">Whether to mask or not the <c>Value</c> (default false).</param>
        /// <remarks>
        ///   <example>
        ///   Examples:
        ///     <code>
        ///     string cnpj = "47158571894466"; cnpj.ToString() -> "47158571894466"
        ///     string cnpj = "47158571894466"; cnpj.ToString(false) -> "47158571894466"
        ///     string cnpj = "47158571894466"; cnpj.ToString(true) -> "47.158.571/8944-66"
        ///     </code>
        ///   </example>
        /// </remarks>
        /// <returns>The string representation of the CNPJ <c>Value</c>, either masked or unmasked.</returns>
        public string ToString(bool masked = false) => masked ? MaskCnpj(Value.ToString()) : Value.ToString();

        private static string MaskCnpj(string cnpj) => $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
    }
}
