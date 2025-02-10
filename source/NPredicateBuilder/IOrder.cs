// <copyright file="IOrder.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder
{
    /// <summary>
    /// An interface that defines an order.
    /// </summary>
    /// <typeparam name="TEntity">The type of the Entity that is being ordered.</typeparam>
    public interface IOrder<TEntity>
    {
        /// <summary>
        /// An interface for ordering against a <see cref="IQueryable"/> entity.
        /// </summary>
        /// <param name="queryable">A list of entities to be ordered against.</param>
        /// <returns>A <see cref="IOrderedQueryable"/> interface that has been ordered.</returns>
        IOrderedQueryable<TEntity> Order(IQueryable<TEntity> queryable);

        /// <summary>
        /// An interface for ordering against a <see cref="IEnumerable{T}"/> entity.
        /// </summary>
        /// <param name="enumerable">A list of entities to be ordered against.</param>
        /// <returns>A <see cref="IOrderedQueryable"/> interface that has been ordered.</returns>
        IOrderedEnumerable<TEntity> Order(IEnumerable<TEntity> enumerable);
    }
}