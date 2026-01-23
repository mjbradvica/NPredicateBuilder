// <copyright file="NPredicateBuilderOrderTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

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
        public void OrderByIEnumerableOrdersCorrectly()
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
        public void OrderByIQueryableOrdersCorrectly()
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
        public void ThenByIEnumerableOrdersCorrectly()
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

            var result = _customers.NPredicateBuilderOrder(order).ToList();

            Assert.AreEqual("Billy", result.First().Name);
            Assert.AreEqual(20, result.First().Age);
        }

        /// <summary>
        /// Ensures multiple orders for IQueryable are correct.
        /// </summary>
        [TestMethod]
        public void ThenByIQueryableOrdersCorrectly()
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
        public void OrderByDescendingIEnumerableOrdersCorrectly()
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
        public void OrderByDescendingIQueryableOrdersCorrectly()
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
        public void ThenByDescendingIEnumerableOrdersCorrectly()
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

            var result = _customers.NPredicateBuilderOrder(order).ToList();

            Assert.AreEqual("Billy", result.First().Name);
            Assert.AreEqual(30, result.First().Age);
        }

        /// <summary>
        /// Ensures multiple orders for IQueryable are correct.
        /// </summary>
        [TestMethod]
        public void ThenByDescendingIQueryableOrdersCorrectly()
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