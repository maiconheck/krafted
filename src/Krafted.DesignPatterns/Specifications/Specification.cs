using System;
using System.Linq.Expressions;

namespace Krafted.DesignPatterns.Specifications
{
    /// <summary>
    /// Represents a base class to Specification Pattern.
    /// </summary>
    /// <typeparam name="TModel">The model to verify.</typeparam>
    public abstract class Specification<TModel>
    {
        /// <summary>
        /// Gets the expression.
        /// </summary>
        /// <returns>The expression.</returns>
        public abstract Expression<Func<TModel, bool>> ToExpression();

        /// <summary>
        /// Determines whether is satisfied by the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <c>true</c> if is satisfied by the specified model; otherwise, <c>false</c>.
        /// </returns>
        public bool IsSatisfiedBy(TModel model)
        {
            Func<TModel, bool> predicate = ToExpression().Compile();
            return predicate(model);
        }
    }
}