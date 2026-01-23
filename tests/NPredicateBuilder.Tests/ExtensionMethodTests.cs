// <copyright file="ExtensionMethodTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NPredicateBuilder.EF;

namespace NPredicateBuilder.Tests
{
    /// <summary>
    /// Tests for the NPredicateBuilder extension methods.
    /// </summary>
    [TestClass]
    public class ExtensionMethodTests
    {
        /// <summary>
        /// Ensures method throws exception on null expression.
        /// </summary>
        [TestMethod]
        public void NPredicateBuilderWhereNullExpressionThrowsException()
        {
            var query = new CustomerTestQuery();

            Assert.ThrowsExactly<ArgumentNullException>(() => new List<Customer>()
                .NPredicateBuilderWhere(query));
        }

        /// <summary>
        /// Ensures method throws exception on null expression.
        /// </summary>
        [TestMethod]
        public void NPredicateBuilderOrderNullExpressionThrowsException()
        {
            var order = new CustomerTestOrder();

            Assert.ThrowsExactly<ArgumentNullException>(() => new List<Customer>()
                .NPredicateBuilderOrder(order));
        }

        /// <summary>
        /// Ensures method throws exception on null expression.
        /// </summary>
        [TestMethod]
        public void NPredicateBuilderEFWhereNullExpressionThrowsException()
        {
            var query = new CustomerTestQuery();

            Assert.ThrowsExactly<ArgumentNullException>(() => new List<Customer>()
                .AsQueryable()
                .NPredicateBuilderEFWhere(query));
        }

        /// <summary>
        /// Ensures method throws exception on null expression.
        /// </summary>
        [TestMethod]
        public void NPredicateBuilderEFOrderNullExpressionThrowsException()
        {
            var order = new CustomerTestOrder();

            Assert.ThrowsExactly<ArgumentNullException>(() => new List<Customer>()
                .AsQueryable()
                .NPredicateBuilderEFOrder(order));
        }
    }
}