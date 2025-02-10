// <copyright file="BaseOrder.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;

namespace NPredicateBuilder
{
    /// <inheritdoc />
    public abstract class BaseOrder<TEntity> : IBaseOrder<TEntity>
    {
        private readonly List<IThenByOrder<TEntity>> _secondaryOrders;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseOrder{TEntity}"/> class.
        /// </summary>
        protected BaseOrder()
        {
            _secondaryOrders = new List<IThenByOrder<TEntity>>();
        }

        /// <inheritdoc />
        public IOrder<TEntity>? FirstOrder { get; private set; }

        /// <inheritdoc />
        public IEnumerable<IThenByOrder<TEntity>> SecondaryOrders => _secondaryOrders.AsEnumerable();

        /// <summary>
        /// States the first order by operation to be executed. If one is already present, this will overwrite the current operation.
        /// </summary>
        /// <typeparam name="TKey">The key that you want to order by.</typeparam>
        /// <param name="orderExpression">The expression that will be used to order a <see cref= "IQueryable{TEntity}"/> or <see cref="IEnumerable{TEntityT}"/>.</param>
        protected void OrderBy<TKey>(Expression<Func<TEntity, TKey>> orderExpression)
        {
            FirstOrder = new OrderBy<TEntity, TKey>(orderExpression);
        }

        /// <summary>
        /// States the first order by descending operation to be executed. If one is already present, this will overwrite the current operation.
        /// </summary>
        /// <typeparam name="TKey">The key that you want to order by descending by.</typeparam>
        /// <param name="orderExpression">The expression that will be used to order a <see cref="IQueryable{TEntity}"/> or <see cref="IEnumerable{TEntity}"/>.</param>
        protected void OrderByDescending<TKey>(Expression<Func<TEntity, TKey>> orderExpression)
        {
            FirstOrder = new OrderByDescending<TEntity, TKey>(orderExpression);
        }

        /// <summary>
        /// States a then by operation to be executed.
        /// </summary>
        /// <typeparam name="TKey">The key that you want to order by after an initial order by has completed.</typeparam>
        /// <param name="orderExpression">The expression that will be used to order a <see cref= "IOrderedQueryable{TEntity}"/> or <see cref="IOrderedEnumerable{TEntity}"/>.</param>
        protected void ThenBy<TKey>(Expression<Func<TEntity, TKey>> orderExpression)
        {
            _secondaryOrders.Add(new ThenBy<TEntity, TKey>(orderExpression));
        }

        /// <summary>
        /// State a then by descending operation to be executed.
        /// </summary>
        /// <typeparam name="TKey">The key that you want to order by descending after an initial order by has completed.</typeparam>
        /// <param name="orderExpression">The expression that will be used to further order a <see cref= "IOrderedQueryable{TEntity}"/> or <see cref="IOrderedEnumerable{TEntity}"/>.</param>
        protected void ThenByDescending<TKey>(Expression<Func<TEntity, TKey>> orderExpression)
        {
            _secondaryOrders.Add(new ThenByDescending<TEntity, TKey>(orderExpression));
        }
    }
}