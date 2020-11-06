using Microsoft.CodeAnalysis;

namespace Krafted.Analyzers
{
    /// <summary>
    /// Provides a Factory Method to the <see cref="DiagnosticDescriptor"/>.
    /// </summary>
    public static class DiagnosticDescriptorFactory
    {
        /// <summary>
        /// Creates a <see cref="DiagnosticDescriptor"/>, which provides description about a <see cref="Diagnostic"/>.
        /// </summary>
        /// <param name="id">A unique identifier for the diagnostic. For example, Krafted.Analyzers diagnostic ID "KT1000".</param>
        /// <param name="title">A short title describing the diagnostic. For example, for CA1001: "Types that own disposable fields should be disposable".</param>
        /// <param name="messageFormat">
        ///   A format message string, which can be passed as the first argument to System.String.Format(System.String,System.Object[])
        ///   when creating the diagnostic message with this descriptor. For example, for CA1001:
        ///   "Implement IDisposable on '{0}' because it creates members of the following IDisposable
        ///   types: '{1}'."
        /// </param>
        /// <param name="category">The category of the diagnostic (like Design, Naming etc.). For example, for KT1000: "Naming". <see cref="DiagnosticCategory"/></param>
        /// <param name="defaultSeverity">Default severity of the diagnostic.</param>
        /// <param name="isEnabledByDefault">True if the diagnostic is enabled by default.</param>
        /// <param name="description">An optional longer description of the diagnostic.</param>
        /// <param name="helpLinkUri">An optional hyperlink that provides a more detailed description regarding the diagnostic.</param>
        /// <param name="customTags">Optional custom tags for the diagnostic. See Microsoft.CodeAnalysis.WellKnownDiagnosticTags for some well known tags.</param>
        /// <returns>A new <see cref="DiagnosticDescriptor"/>, which provides description about a <see cref="Diagnostic"/>.</returns>
        public static DiagnosticDescriptor Create(
            string id,
            string title,
            string messageFormat,
            DiagnosticCategory category,
            DiagnosticSeverity defaultSeverity = DiagnosticSeverity.Warning,
            bool isEnabledByDefault = true,
            string description = null,
            string helpLinkUri = null,
            params string[] customTags)
        {
            return new DiagnosticDescriptor(id, title, messageFormat, category.Name, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags);
        }
    }
}
