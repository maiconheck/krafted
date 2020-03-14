namespace Krafted.DesignPatterns.Factories
{
    /// <summary>
    /// Represents the AbstractFactory participant [Gamma et al.] to the <see cref="IAbstractProduct"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
    /// <typeparam name="T2">The type of the second parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
    /// <typeparam name="T3">The type of the third parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
    public interface IAbstractFactory<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Creates a <see cref="IAbstractProduct"/>.
        /// </summary>
        /// <param name="param1">The first parameter.</param>
        /// <param name="param2">The second parameter.</param>
        /// <param name="param3">The third parameter.</param>
        /// <param name="param4">The fourth parameter.</param>
        /// <param name="param5">The fifth parameter.</param>
        /// <returns>The <see cref="IAbstractProduct"/>.</returns>
        IAbstractProduct New(T1 @param1, T2 @param2, T3 @param3, T4 @param4, T5 @param5);
    }
}