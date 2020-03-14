using System;

namespace Krafted.DesignPatterns.Factories
{
    /// <summary>
    /// Represents a Factory Method [Gamma et al.] to the <see cref="IAbstractProduct"/>.
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Creates a <see cref="IAbstractProduct"/>.
        /// </summary>
        /// <typeparam name="TConcreteFactory">The type of the ConcreteFactory [Gamma et al.].</typeparam>
        /// <returns>The <see cref="IAbstractProduct"/>.</returns>
        public static IAbstractProduct New<TConcreteFactory>()
            where TConcreteFactory : IAbstractFactory
        {
            var factory = (TConcreteFactory)Activator.CreateInstance(typeof(TConcreteFactory));
            return factory.New();
        }

        /// <summary>
        /// Creates a <see cref="IAbstractProduct"/>.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <typeparam name="TConcreteFactory">The type of the ConcreteFactory [Gamma et al.].</typeparam>
        /// <typeparam name="T1">The type of the parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <returns>The <see cref="IAbstractProduct"/>.</returns>
        public static IAbstractProduct New<TConcreteFactory, T1>(T1 @param)
            where TConcreteFactory : IAbstractFactory<T1>
        {
            var factory = (TConcreteFactory)Activator.CreateInstance(typeof(TConcreteFactory));
            return factory.New(@param);
        }

        /// <summary>
        /// Creates a <see cref="IAbstractProduct"/>.
        /// </summary>
        /// <param name="param1">The first parameter.</param>
        /// <param name="param2">The second parameter.</param>
        /// <typeparam name="TConcreteFactory">The type of the ConcreteFactory [Gamma et al.].</typeparam>
        /// <typeparam name="T1">The type of the first parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <returns>The <see cref="IAbstractProduct"/>.</returns>
        public static IAbstractProduct New<TConcreteFactory, T1, T2>(T1 @param1, T2 @param2)
            where TConcreteFactory : IAbstractFactory<T1, T2>
        {
            var factory = (TConcreteFactory)Activator.CreateInstance(typeof(TConcreteFactory));
            return factory.New(@param1, @param2);
        }

        /// <summary>
        /// Creates a <see cref="IAbstractProduct"/>.
        /// </summary>
        /// <param name="param1">The first parameter.</param>
        /// <param name="param2">The second parameter.</param>
        /// <param name="param3">The third parameter.</param>
        /// <typeparam name="TConcreteFactory">The type of the ConcreteFactory [Gamma et al.].</typeparam>
        /// <typeparam name="T1">The type of the first parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <returns>The <see cref="IAbstractProduct"/>.</returns>
        public static IAbstractProduct New<TConcreteFactory, T1, T2, T3>(T1 @param1, T2 @param2, T3 @param3)
            where TConcreteFactory : IAbstractFactory<T1, T2, T3>
        {
            var factory = (TConcreteFactory)Activator.CreateInstance(typeof(TConcreteFactory));
            return factory.New(@param1, @param2, @param3);
        }

        /// <summary>
        /// Creates a <see cref="IAbstractProduct"/>.
        /// </summary>
        /// <param name="param1">The first parameter.</param>
        /// <param name="param2">The second parameter.</param>
        /// <param name="param3">The third parameter.</param>
        /// <param name="param4">The fourth parameter.</param>
        /// <typeparam name="TConcreteFactory">The type of the ConcreteFactory [Gamma et al.].</typeparam>
        /// <typeparam name="T1">The type of the first parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <returns>The <see cref="IAbstractProduct"/>.</returns>
        public static IAbstractProduct New<TConcreteFactory, T1, T2, T3, T4>(T1 @param1, T2 @param2, T3 @param3, T4 @param4)
            where TConcreteFactory : IAbstractFactory<T1, T2, T3, T4>
        {
            var factory = (TConcreteFactory)Activator.CreateInstance(typeof(TConcreteFactory));
            return factory.New(@param1, @param2, @param3, @param4);
        }

        /// <summary>
        /// Creates a <see cref="IAbstractProduct"/>.
        /// </summary>
        /// <param name="param1">The first parameter.</param>
        /// <param name="param2">The second parameter.</param>
        /// <param name="param3">The third parameter.</param>
        /// <param name="param4">The fourth parameter.</param>
        /// <param name="param5">The fifth parameter.</param>
        /// <typeparam name="TConcreteFactory">The type of the ConcreteFactory [Gamma et al.].</typeparam>
        /// <typeparam name="T1">The type of the first parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter to create the <see cref="IAbstractProduct"/>.</typeparam>
        /// <returns>The <see cref="IAbstractProduct"/>.</returns>
        public static IAbstractProduct New<TConcreteFactory, T1, T2, T3, T4, T5>(T1 @param1, T2 @param2, T3 @param3, T4 @param4, T5 @param5)
            where TConcreteFactory : IAbstractFactory<T1, T2, T3, T4, T5>
        {
            var factory = (TConcreteFactory)Activator.CreateInstance(typeof(TConcreteFactory));
            return factory.New(@param1, @param2, @param3, @param4, @param5);
        }
    }
}
