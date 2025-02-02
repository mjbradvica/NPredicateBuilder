// <copyright file="IBaseQuery.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;

namespace NPredicateBuilder
{
    /// <summary>
    /// A base class used to build Where clause queries against an entity.
    /// </summary>
    /// <typeparam name="TEntity">The entity to be queried against.</typeparam>
    public interface IBaseQuery<TEntity>
    {
        /// <summary>
        /// Gets the current Expression that will be used to query a collection.
        /// </summary>
        Expression<Func<TEntity, bool>>? SearchExpression { get; }
    }
}