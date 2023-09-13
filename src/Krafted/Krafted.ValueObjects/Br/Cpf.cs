using System.Diagnostics.CodeAnalysis;
using Krafted.Guards;

namespace Krafted.ValueObjects.Br
{
    /// <summary>
    /// Represents a Brazilian individual taxpayer identification number value object.
    /// <para>
    /// CPF stands for "Cadastro de Pessoa Física" in Brazil.
    /// It's used to identify an individual taxpayer in Brazil.
    /// <see href="https://pt.wikipedia.org/wiki/Cadastro_de_Pessoas_F%C3%ADsicas">See more</see>.
    /// </para>
    /// </summary>
    public class Cpf : ValueObject<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cpf"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Cpf(string value)
        {
            Guard.Against.InvalidCpf(value);
            Value = value;
        }

        // Required for the ORM.
        [ExcludeFromCodeCoverage]
        private Cpf()
        {
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="Cpf"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Cpf(string value) => new Cpf(value);

        /// <summary>
        /// Initializes a new instance of the <see cref="Cpf"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A new instance of the <see cref="Cpf"/> class.</returns>
        public static Cpf NewCpf(string value) => new Cpf(value);

        /// <summary>
        /// Returns the string representation of the CPF <c>Value</c>.
        /// <para>
        /// If the <c>masked</c> argument is <c>true</c>, the <c>Value</c> is masked; otherwise, the <c>Value</c> is unmasked.
        /// </para>
        /// </summary>
        /// <param name="masked">Whether to mask or not the <c>Value</c> (default false).</param>
        /// <remarks>
        ///   <example>
        ///   Examples:
        ///     <code>
        ///     string cpf = "07575768009"; cpf.ToString() -> "07575768009"
        ///     string cpf = "07575768009"; cpf.ToString(false) -> "07575768009"
        ///     string cpf = "07575768009"; cpf.ToString(true) -> "075.757.680-09"
        ///     </code>
        ///   </example>
        /// </remarks>
        /// <returns>The string representation of the CPF <c>Value</c>, either masked or unmasked.</returns>
        public string ToString(bool masked = false) => masked ? MaskCpf(Value.ToString()) : Value.ToString();

        private static string MaskCpf(string cpf) => $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
    }
}
