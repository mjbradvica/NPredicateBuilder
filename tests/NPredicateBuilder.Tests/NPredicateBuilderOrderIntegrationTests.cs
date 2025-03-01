﻿// <copyright file="NPredicateBuilderOrderIntegrationTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPredicateBuilder.EF;

namespace NPredicateBuilder.Tests
{
    /// <summary>
    /// Order tests for EF databases.
    /// </summary>
    [TestClass]
    public class NPredicateBuilderOrderIntegrationTests : BaseIntegrationTest
    {
        /// <summary>
        /// Ensure orders for databases are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task OrderBy_OrdersCorrectlyAsync()
        {
            var customers = new List<Customer>
            {
                TestHelper.Bobby(),
                TestHelper.Billy(),
                TestHelper.Bobby(),
            };

            await using (var context = new TestContext(ContextOptions))
            {
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }

            List<Customer> results;

            await using (var context = new TestContext(ContextOptions))
            {
                var order = new CustomerTestOrder().ByName();

                results = await context.Customers
                    .NPredicateBuilderEFOrder(order)
                    .ToListAsync();
            }

            Assert.AreEqual("Billy", results.First().Name);
        }

        /// <summary>
        /// Ensures multiple orders for databases are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ThenBy_OrdersCorrectlyAsync()
        {
            var customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Bobby", 30),
                new Customer(Guid.NewGuid(), "Billy", 30),
                new Customer(Guid.NewGuid(), "Billy", 20),
            };

            await using (var context = new TestContext(ContextOptions))
            {
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }

            List<Customer> results;

            await using (var context = new TestContext(ContextOptions))
            {
                var order = new CustomerTestOrder()
                    .ByName()
                    .ThenByAge();

                results = await context.Customers
                    .NPredicateBuilderEFOrder(order)
                    .ToListAsync();
            }

            Assert.AreEqual("Billy", results.First().Name);
            Assert.AreEqual(20, results.First().Age);
        }

        /// <summary>
        /// Ensures multiple orders for databases are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task OrderByDescending_OrdersCorrectlyAsync()
        {
            var customers = new List<Customer>
            {
                TestHelper.Bobby(),
                TestHelper.Billy(),
                TestHelper.Bobby(),
            };

            await using (var context = new TestContext(ContextOptions))
            {
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }

            List<Customer> results;

            await using (var context = new TestContext(ContextOptions))
            {
                var order = new CustomerTestOrder()
                    .ByNameDescending();

                results = await context.Customers
                    .NPredicateBuilderEFOrder(order)
                    .ToListAsync();
            }

            Assert.AreEqual("Billy", results.Last().Name);
        }

        /// <summary>
        /// Ensures multiple orders for databases are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ThenByDescending_OrdersCorrectly()
        {
            var customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Bobby", 30),
                new Customer(Guid.NewGuid(), "Billy", 30),
                new Customer(Guid.NewGuid(), "Billy", 20),
            };

            await using (var context = new TestContext(ContextOptions))
            {
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }

            List<Customer> results;

            await using (var context = new TestContext(ContextOptions))
            {
                var order = new CustomerTestOrder()
                    .ByName()
                    .ThenByAgeDescending();

                results = await context.Customers
                    .NPredicateBuilderEFOrder(order)
                    .ToListAsync();
            }

            Assert.AreEqual("Billy", results.First().Name);
            Assert.AreEqual(30, results.First().Age);
        }
    }
}