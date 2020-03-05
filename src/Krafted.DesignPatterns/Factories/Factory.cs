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
            where TConcreteFactory : AbstractFactory
        {
            var factory = (TConcreteFactory)Activator.CreateInstance(typeof(TConcreteFactory));
            return factory.New();
        }
    }
}
