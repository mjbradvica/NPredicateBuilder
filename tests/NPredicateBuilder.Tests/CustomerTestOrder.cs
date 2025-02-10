// <copyright file="CustomerTestOrder.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder.Tests
{
    /// <summary>
    /// Order class for testing purposes.
    /// </summary>
    public class CustomerTestOrder : BaseOrder<Customer>
    {
        /// <summary>
        /// Order for test.
        /// </summary>
        /// <returns>An order for testing.</returns>
        public CustomerTestOrder ByName()
        {
            OrderBy(x => x.Name);

            return this;
        }

        /// <summary>
        /// Order for test.
        /// </summary>
        /// <returns>An order for testing.</returns>
        public CustomerTestOrder ByNameDescending()
        {
            OrderByDescending(x => x.Name);

            return this;
        }

        /// <summary>
        /// Order for test.
        /// </summary>
        /// <returns>An order for testing.</returns>
        public CustomerTestOrder ThenByAge()
        {
            ThenBy(x => x.Age);

            return this;
        }

        /// <summary>
        /// Order for test.
        /// </summary>
        /// <returns>An order for testing.</returns>
        public CustomerTestOrder ThenByAgeDescending()
        {
            ThenByDescending(x => x.Age);

            return this;
        }
    }
}