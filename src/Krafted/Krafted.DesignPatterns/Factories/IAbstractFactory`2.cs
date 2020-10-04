namespace Krafted.DesignPatterns.Factories
{
    /// <summary>
    /// Represents the AbstractFactory participant [Gamma et al.] to the <see cref="IAbstractProduct"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
    /// <typeparam name="T2">The type of the second parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
    public interface IAbstractFactory<T1, T2>
    {
        /// <summary>
        /// Creates a <see cref="IAbstractProduct"/>.
        /// </summary>
        /// <param name="param1">The first parameter.</param>
        /// <param name="param2">The second parameter.</param>
        /// <returns>The <see cref="IAbstractProduct"/>.</returns>
        IAbstractProduct New(T1 @param1, T2 @param2);
    }
}