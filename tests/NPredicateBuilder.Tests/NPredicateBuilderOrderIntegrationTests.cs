// <copyright file="NPredicateBuilderOrderIntegrationTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPredicateBuilder.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NPredicateBuilder.Tests
{
    /// <summary>
    /// Order tests for EF databases.
    /// </summary>
    [TestClass]
    public class NPredicateBuilderOrderIntegrationTests
    {
        /// <summary>
        /// Ensure orders for databases are correct.
        /// </summary>
        [TestMethod]
        public void OrderBy_OrdersCorrectly()
        {
            TestHelper.ClearCustomers();

            var customers = new List<Customer>
            {
                TestHelper.Bobby(),
                TestHelper.Billy(),
                TestHelper.Bobby(),
            };

            using (var context = new TestContext())
            {
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            using (var context = new TestContext())
            {
                var order = new CustomerTestOrder().ByName();

                var result = context.Customers.NPredicateBuilderEFOrder(order).ToList();

                Assert.AreEqual("Billy", result.First().Name);
            }
        }

        /// <summary>
        /// Ensures multiple orders for databases are correct.
        /// </summary>
        [TestMethod]
        public void ThenBy_OrdersCorrectly()
        {
            TestHelper.ClearCustomers();

            var customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Bobby", 30),
                new Customer(Guid.NewGuid(), "Billy", 30),
                new Customer(Guid.NewGuid(), "Billy", 20),
            };

            using (var context = new TestContext())
            {
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            using (var context = new TestContext())
            {
                var order = new CustomerTestOrder()
                    .ByName()
                    .ThenByAge();

                var result = context.Customers.NPredicateBuilderEFOrder(order).ToList();

                Assert.AreEqual("Billy", result.First().Name);
                Assert.AreEqual(20, result.First().Age);
            }
        }

        /// <summary>
        /// Ensures multiple orders for databases are correct.
        /// </summary>
        [TestMethod]
        public void OrderByDescending_OrdersCorrectly()
        {
            TestHelper.ClearCustomers();

            var customers = new List<Customer>
            {
                TestHelper.Bobby(),
                TestHelper.Billy(),
                TestHelper.Bobby(),
            };

            using (var context = new TestContext())
            {
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            using (var context = new TestContext())
            {
                var order = new CustomerTestOrder().ByNameDescending();

                var result = context.Customers.NPredicateBuilderEFOrder(order).ToList();

                Assert.AreEqual("Billy", result.Last().Name);
            }
        }

        /// <summary>
        /// Ensures multiple orders for databases are correct.
        /// </summary>
        [TestMethod]
        public void ThenByDescending_OrdersCorrectly()
        {
            TestHelper.ClearCustomers();

            var customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Bobby", 30),
                new Customer(Guid.NewGuid(), "Billy", 30),
                new Customer(Guid.NewGuid(), "Billy", 20),
            };

            using (var context = new TestContext())
            {
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            using (var context = new TestContext())
            {
                var order = new CustomerTestOrder()
                    .ByName()
                    .ThenByAgeDescending();

                var result = context.Customers.NPredicateBuilderEFOrder(order).ToList();

                Assert.AreEqual("Billy", result.First().Name);
                Assert.AreEqual(30, result.First().Age);
            }
        }
    }
}