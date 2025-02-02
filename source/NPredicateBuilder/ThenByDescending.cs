// <copyright file="ThenByDescending.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;

namespace NPredicateBuilder
{
    /// <inheritdoc />
    internal class ThenByDescending<TEntity, TKey> : IThenByOrder<TEntity>
    {
        private readonly Expression<Func<TEntity, TKey>> _orderExpression;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThenByDescending{TEntity, TKey}"/> class.
        /// </summary>
        /// <param name="orderExpression">A func for describing a descending continuation order for an entity.</param>
        public ThenByDescending(Expression<Func<TEntity, TKey>> orderExpression)
        {
            _orderExpression = orderExpression;
        }

        /// <inheritdoc />
        public IOrderedQueryable<TEntity> Order(IOrderedQueryable<TEntity> orderedQueryable)
        {
            return orderedQueryable.ThenByDescending(_orderExpression);
        }

        /// <inheritdoc />
        public IOrderedEnumerable<TEntity> Order(IOrderedEnumerable<TEntity> orderedEnumerable)
        {
            return orderedEnumerable.ThenByDescending(_orderExpression.Compile());
        }
    }
}