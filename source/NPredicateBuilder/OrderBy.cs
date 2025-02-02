// <copyright file="OrderBy.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;

namespace NPredicateBuilder
{
    /// <inheritdoc />
    internal class OrderBy<TEntity, TKey> : IOrder<TEntity>
    {
        private readonly Expression<Func<TEntity, TKey>> _orderExpression;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderBy{TEntity, TKey}"/> class.
        /// </summary>
        /// <param name="orderExpression">A func that describes how an entity should be ordered by.</param>
        public OrderBy(Expression<Func<TEntity, TKey>> orderExpression)
        {
            _orderExpression = orderExpression;
        }

        /// <inheritdoc/>
        public IOrderedQueryable<TEntity> Order(IQueryable<TEntity> queryable)
        {
            return queryable.OrderBy(_orderExpression);
        }

        /// <inheritdoc/>
        public IOrderedEnumerable<TEntity> Order(IEnumerable<TEntity> enumerable)
        {
            return enumerable.OrderBy(_orderExpression.Compile());
        }
    }
}