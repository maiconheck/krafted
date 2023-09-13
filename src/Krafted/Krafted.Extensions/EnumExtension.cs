using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Krafted.Guards;

namespace System
{
    /// <summary>
    /// Provides extension methods to <see cref="Enum"/>.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Gets the enum display name.
        /// </summary>
        /// <param name="input">The enum constant to get the display name from.</param>
        /// <param name="fallback">When <c>true</c>, if the enum constant is not decorated with the <see cref="DisplayAttribute"/>, fall-backs the enum constant string representation.</param>
        /// <returns>The enum display name.</returns>
        /// <exception cref="ArgumentException">Throws when the enum constant '{input}' is not decorated with the <see cref="DisplayAttribute"/> and the <paramref name="fallback"/> is <c>false</c>.</exception>
        public static string GetDisplayName(this Enum input, bool fallback = false)
        {
            Guard.Against.Null(input);

            var member = input
                .GetType()
                .GetMember(input.ToString())[0];

            bool defined = member.IsDefined(typeof(DisplayAttribute), false);

            if (!defined && !fallback)
                throw new ArgumentException($"The enum constant '{input}' is not decorated with the DisplayAttribute.", nameof(input));

            if (!defined && fallback)
                return input.ToString();

            return member
                .GetCustomAttribute<DisplayAttribute>()!
                .GetName()!;
        }
    }
}
