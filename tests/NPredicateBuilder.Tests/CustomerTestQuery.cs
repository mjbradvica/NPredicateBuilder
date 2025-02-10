// <copyright file="CustomerTestQuery.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder.Tests
{
    /// <summary>
    /// Query for testing.
    /// </summary>
    public class CustomerTestQuery : BaseQuery<Customer>
    {
        /// <summary>
        /// Query for test.
        /// </summary>
        /// <returns>An instance of <see cref="CustomerTestQuery"/>.</returns>
        public CustomerTestQuery AndNameIsBobby()
        {
            AddAndCriteria(x => x.Name == "Bobby");

            return this;
        }

        /// <summary>
        /// Query for test.
        /// </summary>
        /// <returns>An instance of <see cref="CustomerTestQuery"/>.</returns>
        public CustomerTestQuery AndNameIsBilly()
        {
            AddAndCriteria(x => x.Name == "Billy");

            return this;
        }

        /// <summary>
        /// Query for test.
        /// </summary>
        /// <returns>An instance of <see cref="CustomerTestQuery"/>.</returns>
        public CustomerTestQuery AndAgeIsOverSix()
        {
            AddAndCriteria(x => x.Age >= 6);

            return this;
        }

        /// <summary>
        /// Query for test.
        /// </summary>
        /// <returns>An instance of <see cref="CustomerTestQuery"/>.</returns>
        public CustomerTestQuery OrAgeIsOverTwenty()
        {
            AddOrCriteria(x => x.Age >= 20);

            return this;
        }
    }
}