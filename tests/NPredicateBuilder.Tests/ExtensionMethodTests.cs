// <copyright file="ExtensionMethodTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void NPredicateBuilderWhere_NullExpression_ThrowsException()
        {
            var query = new CustomerTestQuery();

            Assert.ThrowsException<ArgumentNullException>(() => new List<Customer>()
                .NPredicateBuilderWhere(query));
        }

        /// <summary>
        /// Ensures method throws exception on null expression.
        /// </summary>
        [TestMethod]
        public void NPredicateBuilderOrder_NullExpression_ThrowsException()
        {
            var order = new CustomerTestOrder();

            Assert.ThrowsException<ArgumentNullException>(() => new List<Customer>()
                .NPredicateBuilderOrder(order));
        }

        /// <summary>
        /// Ensures method throws exception on null expression.
        /// </summary>
        [TestMethod]
        public void NPredicateBuilderEFWhere_NullExpression_ThrowsException()
        {
            var query = new CustomerTestQuery();

            Assert.ThrowsException<ArgumentNullException>(() => new List<Customer>()
                .AsQueryable()
                .NPredicateBuilderEFWhere(query));
        }

        /// <summary>
        /// Ensures method throws exception on null expression.
        /// </summary>
        [TestMethod]
        public void NPredicateBuilderEFOrder_NullExpression_ThrowsException()
        {
            var order = new CustomerTestOrder();

            Assert.ThrowsException<ArgumentNullException>(() => new List<Customer>()
                .AsQueryable()
                .NPredicateBuilderEFOrder(order));
        }
    }
}