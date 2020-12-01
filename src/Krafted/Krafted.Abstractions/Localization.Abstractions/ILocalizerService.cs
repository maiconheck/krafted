namespace Krafted.Localization.Abstractions
{
    /// <summary>
    /// Provides a service to gets localized resource values.
    /// </summary>
    public interface ILocalizerService
    {
        /// <summary>
        /// Gets the string resource value with the given name.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        /// <returns>The string resource as a Microsoft.Extensions.Localization.LocalizedString.</returns>
        string GetValue(string name);
    }
}
