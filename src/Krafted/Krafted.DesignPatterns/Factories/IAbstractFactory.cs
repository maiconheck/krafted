namespace Krafted.DesignPatterns.Factories
{
    /// <summary>
    /// Represents the AbstractFactory participant [Gamma et al.] to the <see cref="IAbstractProduct"/>.
    /// </summary>
    public interface IAbstractFactory
    {
        /// <summary>
        /// Creates a <see cref="IAbstractProduct"/>.
        /// </summary>
        /// <returns>The <see cref="IAbstractProduct"/>.</returns>
        IAbstractProduct New();
    }
}
