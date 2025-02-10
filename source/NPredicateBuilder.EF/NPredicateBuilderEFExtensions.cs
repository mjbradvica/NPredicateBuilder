// <copyright file="NPredicateBuilderEFExtensions.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using LinqKit;

namespace NPredicateBuilder.EF
{
    /// <summary>
    /// A series of extension methods for applying Queries and Orders against a <see cref="IQueryable"/> interface.
    /// </summary>
    public static class NPredicateBuilderEFExtensions
    {
        /// <summary>
        /// Applies a series of predicates as filters on a <see cref="IQueryable{TEntity}"/>.
        /// </summary>
        /// <typeparam name="TEntity">The entity that you are querying.</typeparam>
        /// <param name="queryable">A <see cref="IQueryable{TEntity}"/>.</param>
        /// <param name="baseQuery">A <see cref="IBaseQuery{TEntity}"/>.</param>
        /// <returns>A filtered <see cref="IQueryable{TEntity}"/>.</returns>
        public static IQueryable<TEntity> NPredicateBuilderEFWhere<TEntity>(this IQueryable<TEntity> queryable, IBaseQuery<TEntity> baseQuery)
        {
            if (baseQuery.SearchExpression == null)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            return queryable.AsExpandable().Where(baseQuery.SearchExpression);
        }

        /// <summary>
        /// Applies a series of orders on a <see cref="IQueryable{TEntity}"/>.
        /// </summary>
        /// <typeparam name="TEntity">The entity that you are ordering.</typeparam>
        /// <param name="queryable">A <see cref="IQueryable{TEntity}"/>.</param>
        /// <param name="baseOrder">A <see cref="IBaseOrder{TEntity}"/>.</param>
        /// <returns>A <see cref="IOrderedQueryable{TEntity}"/>.</returns>
        public static IOrderedQueryable<TEntity> NPredicateBuilderEFOrder<TEntity>(this IQueryable<TEntity> queryable, IBaseOrder<TEntity> baseOrder)
        {
            if (baseOrder.FirstOrder == null)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            var orderedEntities = baseOrder.FirstOrder.Order(queryable);

            foreach (var orderer in baseOrder.SecondaryOrders)
            {
                orderedEntities = orderer.Order(orderedEntities);
            }

            return orderedEntities;
        }
    }
}