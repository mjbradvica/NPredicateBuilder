// <copyright file="NPredicateBuilderOrderTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPredicateBuilder.EF;

namespace NPredicateBuilder.Tests
{
    /// <summary>
    /// Tests for ordering.
    /// </summary>
    [TestClass]
    public class NPredicateBuilderOrderTests
    {
        private IEnumerable<Customer>? _customers;

        /// <summary>
        /// Ensures ordering for IEnumerable are correct.
        /// </summary>
        [TestMethod]
        public void OrderBy_IEnumerable_OrdersCorrectly()
        {
            _customers = new List<Customer>
            {
                TestHelper.Bobby(),
                TestHelper.Billy(),
                TestHelper.Bobby(),
            };

            var order = new CustomerTestOrder().ByName();

            var result = _customers.NPredicateBuilderOrder(order);

            Assert.AreEqual("Billy", result.First().Name);
        }

        /// <summary>
        /// Ensures orders for IQueryable are correct.
        /// </summary>
        [TestMethod]
        public void OrderBy_IQueryable_OrdersCorrectly()
        {
            _customers = new List<Customer>
            {
                TestHelper.Bobby(),
                TestHelper.Billy(),
                TestHelper.Bobby(),
            };

            var order = new CustomerTestOrder().ByName();

            var result = _customers.AsQueryable().NPredicateBuilderEFOrder(order);

            Assert.AreEqual("Billy", result.First().Name);
        }

        /// <summary>
        /// Ensures multiple orders for IEnumerable are correct.
        /// </summary>
        [TestMethod]
        public void ThenBy_IEnumerable_OrdersCorrectly()
        {
            _customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Bobby", 30),
                new Customer(Guid.NewGuid(), "Billy", 30),
                new Customer(Guid.NewGuid(), "Billy", 20),
            };

            var order = new CustomerTestOrder()
                .ByName()
                .ThenByAge();

            var result = _customers.NPredicateBuilderOrder(order);

            Assert.AreEqual("Billy", result.First().Name);
            Assert.AreEqual(20, result.First().Age);
        }

        /// <summary>
        /// Ensures multiple orders for IQueryable are correct.
        /// </summary>
        [TestMethod]
        public void ThenBy_IQueryable_OrdersCorrectly()
        {
            _customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Bobby", 30),
                new Customer(Guid.NewGuid(), "Billy", 30),
                new Customer(Guid.NewGuid(), "Billy", 20),
            };

            var order = new CustomerTestOrder()
                .ByName()
                .ThenByAge();

            var result = _customers.AsQueryable().NPredicateBuilderEFOrder(order);

            Assert.AreEqual("Billy", result.First().Name);
            Assert.AreEqual(20, result.First().Age);
        }

        /// <summary>
        /// Ensures multiple orders for IEnumerable are correct.
        /// </summary>
        [TestMethod]
        public void OrderByDescending_IEnumerable_OrdersCorrectly()
        {
            _customers = new List<Customer>
            {
                TestHelper.Bobby(),
                TestHelper.Billy(),
                TestHelper.Bobby(),
            };

            var order = new CustomerTestOrder().ByNameDescending();

            var result = _customers.NPredicateBuilderOrder(order);

            Assert.AreEqual("Billy", result.Last().Name);
        }

        /// <summary>
        /// Ensures multiple orders for IQueryable are correct.
        /// </summary>
        [TestMethod]
        public void OrderByDescending_IQueryable_OrdersCorrectly()
        {
            _customers = new List<Customer>
            {
                TestHelper.Bobby(),
                TestHelper.Billy(),
                TestHelper.Bobby(),
            };

            var order = new CustomerTestOrder().ByNameDescending();

            var result = _customers.AsQueryable().NPredicateBuilderEFOrder(order);

            Assert.AreEqual("Billy", result.Last().Name);
        }

        /// <summary>
        /// Ensures multiple orders for IEnumerable are correct.
        /// </summary>
        [TestMethod]
        public void ThenByDescending_IEnumerable_OrdersCorrectly()
        {
            _customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Bobby", 30),
                new Customer(Guid.NewGuid(), "Billy", 30),
                new Customer(Guid.NewGuid(), "Billy", 20),
            };

            var order = new CustomerTestOrder()
                .ByName()
                .ThenByAgeDescending();

            var result = _customers.NPredicateBuilderOrder(order);

            Assert.AreEqual("Billy", result.First().Name);
            Assert.AreEqual(30, result.First().Age);
        }

        /// <summary>
        /// Ensures multiple orders for IQueryable are correct.
        /// </summary>
        [TestMethod]
        public void ThenByDescending_IQueryable_OrdersCorrectly()
        {
            _customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Bobby", 30),
                new Customer(Guid.NewGuid(), "Billy", 30),
                new Customer(Guid.NewGuid(), "Billy", 20),
            };

            var order = new CustomerTestOrder()
                .ByName()
                .ThenByAgeDescending();

            var result = _customers.AsQueryable().NPredicateBuilderEFOrder(order);

            Assert.AreEqual("Billy", result.First().Name);
            Assert.AreEqual(30, result.First().Age);
        }
    }
}