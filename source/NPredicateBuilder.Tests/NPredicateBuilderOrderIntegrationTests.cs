﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPredicateBuilder.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NPredicateBuilder.Tests
{
    [TestClass]
    public class NPredicateBuilderOrderIntegrationTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NPredicateBuilderOrderIntegrationTests"/> class.
        /// </summary>
        public NPredicateBuilderOrderIntegrationTests()
        {
            using (var context = new TestContext())
            {
                var allCustomers = context.Customers;
                context.Customers.RemoveRange(allCustomers);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void OrderBy_OrdersCorrectly()
        {
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

        [TestMethod]
        public void ThenBy_OrdersCorrectly()
        {
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

        [TestMethod]
        public void OrderByDescending_OrdersCorrectly()
        {
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

        [TestMethod]
        public void ThenByDescending_OrdersCorrectly()
        {
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