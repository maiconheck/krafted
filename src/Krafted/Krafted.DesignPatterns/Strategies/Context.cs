using System.Collections.Generic;

namespace Krafted.DesignPatterns.Strategies
{
    /// <summary>
    /// Represents the Context participant [Gamma et al.].
    /// </summary>
    public class Context
    {
        private readonly IEnumerable<AbstractStrategy> _strategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// </summary>
        /// <param name="strategies">The strategies.</param>
        public Context(IEnumerable<AbstractStrategy> strategies)
            => _strategies = strategies;
    }
}