using System;

namespace Krafted.DesignPatterns.Factories
{
    /// <summary>
    /// Represents the AbstractFactory participant [Gamma et al.] to the <see cref="IAbstractProduct"/>.
    /// </summary>
    public abstract class AbstractFactory
    {
        /// <summary>
        /// Creates a <see cref="IAbstractProduct"/>.
        /// </summary>
        /// <returns>The <see cref="IAbstractProduct"/>.</returns>
        public abstract IAbstractProduct New();
    }
}
