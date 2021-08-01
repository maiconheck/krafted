// A Specification Pattern implementation.
//
// This class is based on the excellent course: Specification Pattern in C# Pluralsight by Vladimir Khorikov.
// Course: https://app.pluralsight.com/library/courses/csharp-specification-pattern/table-of-contents
// Source: https://github.com/vkhorikov/SpecPattern
// Retrieved in July 2020.

using System;
using System.Linq.Expressions;

namespace Krafted.DesignPatterns.Specifications
{
    /// <summary>
    /// Represents a base class to Specification Pattern.
    /// </summary>
    /// <typeparam name="T">The model to verify.</typeparam>
    public abstract class Specification<T>
    {
        /// <summary>
        /// Starting point that return an initialized specification to allows us to build up new specifications on top of it.
        /// </summary>
        public static readonly Specification<T> Default = new IdentitySpecification<T>();

        /// <summary>
        /// Determines whether is satisfied by the specified model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        ///   <c>true</c> if is satisfied by the specified entity; otherwise, <c>false</c>.
        /// </returns>
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }

        /// <summary>
        /// Gets the expression.
        /// </summary>
        /// <returns>The expression.</returns>
        public abstract Expression<Func<T, bool>> ToExpression();

        /// <summary>
        /// Adds an And specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The And specification.</returns>
        public Specification<T> And(Specification<T> specification)
        {
            if (this == Default)
                return specification;

            if (specification == Default)
                return this;

            return new AndSpecification<T>(this, specification);
        }

        /// <summary>
        /// Adds an Or specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The Or specification.</returns>
        public Specification<T> Or(Specification<T> specification)
        {
            if (this == Default || specification == Default)
                return Default;

            return new OrSpecification<T>(this, specification);
        }

        /// <summary>
        /// Adds an Not specification.
        /// </summary>
        /// <returns>The Not specification.</returns>
        public Specification<T> Not() => new NotSpecification<T>(this);
    }
}
