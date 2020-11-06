using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Krafted.Analyzers
{
    /// <summary>
    /// Represents the diagnostic categories.
    /// </summary>
    /// <remarks>
    /// Implemented using the type-safe enums pattern.
    /// </remarks>
    public sealed class DiagnosticCategory
    {
        private DiagnosticCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static DiagnosticCategory Style { get; } = new DiagnosticCategory("Style", "The style category");

        public static DiagnosticCategory Readability { get; } = new DiagnosticCategory("Readability", "The readability category");

        public static DiagnosticCategory Maintainability { get; } = new DiagnosticCategory("Maintainability", "The maintainability category");

        public static DiagnosticCategory Redundancy { get; } = new DiagnosticCategory("Redundancy", "The redundancy category");

        public static DiagnosticCategory Naming { get; } = new DiagnosticCategory("Naming", "The naming category");

        public static DiagnosticCategory Design { get; } = new DiagnosticCategory("Design", "The design category");

        public static DiagnosticCategory Performance { get; } = new DiagnosticCategory("Performance", "The rerformance category");

        public string Name { get; }

        public string Description { get; }

        /// <summary>
        /// Performs an explicit conversion from <see cref="DiagnosticCategory"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <example>
        ///    <code>string value = (string)DiagnosticCategory.Style; // value is "Style"</code>
        /// </example>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator string(DiagnosticCategory category)
        {
            return category.Name;
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="DiagnosticCategory"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <example>
        ///    <code>DiagnosticCategory category = (DiagnosticCategory)"Readability"; // category.Name is "Readability"</code>
        /// </example>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator DiagnosticCategory(string name) => GetValue(name);

        public static IEnumerable<string> GetNames() => GetValues().Select(category => category.Name);

        public static DiagnosticCategory GetValue(string name) => GetValues().First(category => category.Name == name);

        public static IReadOnlyList<DiagnosticCategory> GetValues()
        {
            return typeof(DiagnosticCategory).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(property => (DiagnosticCategory)property.GetValue(null))
                .ToList();
        }

        public override string ToString() => Name;
    }
}
