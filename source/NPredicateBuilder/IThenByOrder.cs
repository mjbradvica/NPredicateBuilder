// <copyright file="IThenByOrder.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder
{
    /// <summary>
    /// An interface for defining a continued order against an entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the Entity that is being further ordered.</typeparam>
    public interface IThenByOrder<TEntity>
    {
        /// <summary>
        /// An interface for further ordering a <see cref="IOrderedQueryable"/> entity.
        /// </summary>
        /// <param name="orderedQueryable">A list of entities to be further ordered.</param>
        /// <returns>A further ordered list of entities.</returns>
        IOrderedQueryable<TEntity> Order(IOrderedQueryable<TEntity> orderedQueryable);

        /// <summary>
        /// An interface for further ordering a <see cref="IOrderedEnumerable{TElement}"/> entity.
        /// </summary>
        /// <param name="orderedEnumerable">A list of entity to be further ordered.</param>
        /// <returns>A further ordered list of entities.</returns>
        IOrderedEnumerable<TEntity> Order(IOrderedEnumerable<TEntity> orderedEnumerable);
    }
}