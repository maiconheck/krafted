namespace Krafted.DesignPatterns.Factories
{
    /// <summary>
    /// Represents the AbstractFactory participant [Gamma et al.] to the <see cref="IAbstractProduct"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
    public interface IAbstractFactory<T1>
    {
        /// <summary>
        /// Creates a <see cref="IAbstractProduct"/>.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <returns>The <see cref="IAbstractProduct"/>.</returns>
        IAbstractProduct New(T1 @param);
    }
}