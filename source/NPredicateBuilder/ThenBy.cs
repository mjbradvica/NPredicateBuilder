// <copyright file="ThenBy.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;

namespace NPredicateBuilder
{
    /// <inheritdoc />
    internal class ThenBy<TEntity, TKey> : IThenByOrder<TEntity>
    {
        private readonly Expression<Func<TEntity, TKey>> _orderExpression;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThenBy{T, TKey}"/> class.
        /// </summary>
        /// <param name="orderExpression">A func to define a continuation of an order for an entity.</param>
        public ThenBy(Expression<Func<TEntity, TKey>> orderExpression)
        {
            _orderExpression = orderExpression;
        }

        /// <inheritdoc/>
        public IOrderedQueryable<TEntity> Order(IOrderedQueryable<TEntity> orderedQueryable)
        {
            return orderedQueryable.ThenBy(_orderExpression);
        }

        /// <inheritdoc/>
        public IOrderedEnumerable<TEntity> Order(IOrderedEnumerable<TEntity> orderedEnumerable)
        {
            return orderedEnumerable.ThenBy(_orderExpression.Compile());
        }
    }
}