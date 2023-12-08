namespace Krafted.ValueObjects;

/// <summary>
/// Defines a <c>ToString(bool masked = false)</c> method to return the string representation of the Value Object, either masked or unmasked.
/// </summary>
public interface IValueObjectMasked
{
    /// <summary>
    /// Returns the string representation of the Value Object, either masked or unmasked.
    /// <para>
    /// If the <c>masked</c> argument is <c>true</c>, the <c>Value</c> is masked; otherwise, the <c>Value</c> is unmasked.
    /// </para>
    /// </summary>
    /// <param name="masked">Whether to mask or not the <c>Value</c> (default false).</param>
    /// <returns>The string representation of the Value Object, either masked or unmasked.</returns>
    public string ToString(bool masked = false);
}
