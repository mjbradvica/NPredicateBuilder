// <copyright file="IBaseOrder.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder
{
    /// <summary>
    /// A base class used to build Order clause's against the entity.
    /// </summary>
    /// <typeparam name="TEntity">The entity to be ordered against.</typeparam>
    public interface IBaseOrder<TEntity>
    {
        /// <summary>
        /// Gets the first order expression. This is used by the OrderBy function.
        /// </summary>
        IOrder<TEntity>? FirstOrder { get; }

        /// <summary>
        /// Gets the secondary order expressions. This is used by the ThenBy functions.
        /// </summary>
        IEnumerable<IThenByOrder<TEntity>> SecondaryOrders { get; }
    }
}