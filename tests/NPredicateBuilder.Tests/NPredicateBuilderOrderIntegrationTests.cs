// <copyright file="NPredicateBuilderOrderIntegrationTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
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
    public class NPredicateBuilderOrderIntegrationTests
    {
        /// <summary>
        /// Ensure orders for databases are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task OrderBy_OrdersCorrectlyAsync()
        {
            await TestHelper.ClearTables();

            var customers = new List<Customer>
            {
                TestHelper.Bobby(),
                TestHelper.Billy(),
                TestHelper.Bobby(),
            };

            await using (var context = new TestContext())
            {
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }

            await using (var context = new TestContext())
            {
                var order = new CustomerTestOrder().ByName();

                var result = await context.Customers
                    .NPredicateBuilderEFOrder(order)
                    .ToListAsync();

                Assert.AreEqual("Billy", result.First().Name);
            }
        }

        /// <summary>
        /// Ensures multiple orders for databases are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ThenBy_OrdersCorrectlyAsync()
        {
            await TestHelper.ClearTables();

            var customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Bobby", 30),
                new Customer(Guid.NewGuid(), "Billy", 30),
                new Customer(Guid.NewGuid(), "Billy", 20),
            };

            await using (var context = new TestContext())
            {
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }

            await using (var context = new TestContext())
            {
                var order = new CustomerTestOrder()
                    .ByName()
                    .ThenByAge();

                var result = await context.Customers
                    .NPredicateBuilderEFOrder(order)
                    .ToListAsync();

                Assert.AreEqual("Billy", result.First().Name);
                Assert.AreEqual(20, result.First().Age);
            }
        }

        /// <summary>
        /// Ensures multiple orders for databases are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task OrderByDescending_OrdersCorrectlyAsync()
        {
            await TestHelper.ClearTables();

            var customers = new List<Customer>
            {
                TestHelper.Bobby(),
                TestHelper.Billy(),
                TestHelper.Bobby(),
            };

            await using (var context = new TestContext())
            {
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }

            await using (var context = new TestContext())
            {
                var order = new CustomerTestOrder()
                    .ByNameDescending();

                var result = await context.Customers
                    .NPredicateBuilderEFOrder(order)
                    .ToListAsync();

                Assert.AreEqual("Billy", result.Last().Name);
            }
        }

        /// <summary>
        /// Ensures multiple orders for databases are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ThenByDescending_OrdersCorrectly()
        {
            await TestHelper.ClearTables();

            var customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Bobby", 30),
                new Customer(Guid.NewGuid(), "Billy", 30),
                new Customer(Guid.NewGuid(), "Billy", 20),
            };

            await using (var context = new TestContext())
            {
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }

            await using (var context = new TestContext())
            {
                var order = new CustomerTestOrder()
                    .ByName()
                    .ThenByAgeDescending();

                var result = await context.Customers
                    .NPredicateBuilderEFOrder(order)
                    .ToListAsync();

                Assert.AreEqual("Billy", result.First().Name);
                Assert.AreEqual(30, result.First().Age);
            }
        }
    }
}