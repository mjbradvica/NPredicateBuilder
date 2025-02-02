// <copyright file="NPredicateBuilderExtensions.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder
{
    /// <summary>
    /// Provides extension methods to query and order against a <see cref="IEnumerable{TEntity}"/> collection.
    /// </summary>
    public static class NPredicateBuilderExtensions
    {
        /// <summary>
        /// Applies a series of predicates as filters on a <see cref="IEnumerable{TEntity}"/>.
        /// </summary>
        /// <typeparam name="TEntity">The entity type that you are querying.</typeparam>
        /// <param name="enumerable">A <see cref="IEnumerable{TEntity}"/> to filter.</param>
        /// <param name="baseQuery">A <see cref="IBaseQuery{TEntity}"/>.</param>
        /// <returns>A filtered <see cref="IEnumerable{TEntity}"/>.</returns>
        public static IEnumerable<TEntity> NPredicateBuilderWhere<TEntity>(this IEnumerable<TEntity> enumerable, IBaseQuery<TEntity> baseQuery)
        {
            if (baseQuery.SearchExpression == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            return enumerable.Where(baseQuery.SearchExpression.Compile());
        }

        /// <summary>
        /// Applies a series of orders on an IEnumerable.
        /// </summary>
        /// <typeparam name="TEntity">The entity type that you are ordering.</typeparam>
        /// <param name="enumerable">A <see cref="IEnumerable{TEntity}"/> to order.</param>
        /// <param name="baseOrder">A <see cref="IBaseOrder{TEntity}"/>.</param>
        /// <returns>A <see cref="IOrderedEnumerable{TEntity}"/>.</returns>
        public static IOrderedEnumerable<TEntity> NPredicateBuilderOrder<TEntity>(this IEnumerable<TEntity> enumerable, IBaseOrder<TEntity> baseOrder)
        {
            if (baseOrder.FirstOrder == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            var orderedEntities = baseOrder.FirstOrder.Order(enumerable);

            foreach (var orderer in baseOrder.SecondaryOrders)
            {
                orderedEntities = orderer.Order(orderedEntities);
            }

            return orderedEntities;
        }
    }
}