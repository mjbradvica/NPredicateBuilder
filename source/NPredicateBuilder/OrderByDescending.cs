// <copyright file="OrderByDescending.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;

namespace NPredicateBuilder
{
    /// <inheritdoc />
    internal class OrderByDescending<TEntity, TKey> : IOrder<TEntity>
    {
        private readonly Expression<Func<TEntity, TKey>> _orderExpression;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderByDescending{TEntity, TKey}"/> class.
        /// </summary>
        /// <param name="orderExpression">A func to describe how and entity should be ordered.</param>
        public OrderByDescending(Expression<Func<TEntity, TKey>> orderExpression)
        {
            _orderExpression = orderExpression;
        }

        /// <inheritdoc/>
        public IOrderedQueryable<TEntity> Order(IQueryable<TEntity> queryable)
        {
            return queryable.OrderByDescending(_orderExpression);
        }

        /// <inheritdoc/>
        public IOrderedEnumerable<TEntity> Order(IEnumerable<TEntity> enumerable)
        {
            return enumerable.OrderByDescending(_orderExpression.Compile());
        }
    }
}