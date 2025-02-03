// <copyright file="NPredicateBuilderWhereIntegrationTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPredicateBuilder.EF;

namespace NPredicateBuilder.Tests
{
    /// <summary>
    /// Tests where filters for EF databases.
    /// </summary>
    [TestClass]
    public class NPredicateBuilderWhereIntegrationTests
    {
        /// <summary>
        /// Ensures where filters for databases are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Where_DbSet_FiltersCorrectly()
        {
            await TestHelper.ClearTables();

            var customers = new List<Customer>
            {
                TestHelper.Billy(),
                TestHelper.Bobby(),
            };

            await using (var context = new TestContext(TestHelper.GetOptions()))
            {
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }

            List<Customer> results;

            await using (var context = new TestContext(TestHelper.GetOptions()))
            {
                var query = new CustomerTestQuery()
                    .AndNameIsBobby();

                results = await context.Customers
                    .NPredicateBuilderEFWhere(query)
                    .ToListAsync();
            }

            Assert.AreEqual("Bobby", results.Single().Name);
        }

        /// <summary>
        /// Ensures multiple filters for databases are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task MultipleAndFilters_FiltersCorrectly()
        {
            await TestHelper.ClearTables();

            var correctCustomer = new Customer(Guid.NewGuid(), "Billy", 10);

            var customers = new List<Customer>
            {
                correctCustomer, new Customer(Guid.NewGuid(), "Billy", 5), TestHelper.Bobby(),
            };

            await using (var context = new TestContext(TestHelper.GetOptions()))
            {
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }

            List<Customer> results;

            await using (var context = new TestContext(TestHelper.GetOptions()))
            {
                var query = new CustomerTestQuery()
                    .AndNameIsBilly().AndAgeIsOverSix();

                results = await context.Customers
                    .NPredicateBuilderEFWhere(query)
                    .ToListAsync();
            }

            Assert.AreEqual(correctCustomer.Name, results.Single().Name);
            Assert.AreEqual(correctCustomer.Age, results.Single().Age);
        }

        /// <summary>
        /// Ensures compound filters for databases are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task CombinedAndOrFilters_FiltersCorrectly()
        {
            await TestHelper.ClearTables();

            var customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Billy", 5),
                new Customer(Guid.NewGuid(), "Billy", 25),
                new Customer(Guid.NewGuid(), "Bobby", 5),
                new Customer(Guid.NewGuid(), "Bobby", 25),
            };

            await using (var context = new TestContext(TestHelper.GetOptions()))
            {
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }

            List<Customer> results;

            await using (var context = new TestContext(TestHelper.GetOptions()))
            {
                var query = new CustomerTestQuery()
                    .AndNameIsBilly().OrAgeIsOverTwenty();

                results = await context.Customers
                    .NPredicateBuilderEFWhere(query)
                    .ToListAsync();
            }

            Assert.AreEqual(3, results.Count);
        }

        /// <summary>
        /// Ensures compound filters for databases are correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task AppendedFilters_FiltersCorrectly()
        {
            await TestHelper.ClearTables();

            var customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Billy", 5),
                new Customer(Guid.NewGuid(), "Billy", 25),
                new Customer(Guid.NewGuid(), "Bobby", 5),
                new Customer(Guid.NewGuid(), "Bobby", 25),
            };

            await using (var context = new TestContext(TestHelper.GetOptions()))
            {
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }

            List<Customer> results;

            await using (var context = new TestContext(TestHelper.GetOptions()))
            {
                var query = new CustomerTestQuery()
                    .AndNameIsBilly().AndAgeIsOverSix()
                    .Or(new CustomerTestQuery().AndNameIsBobby());

                results = await context.Customers
                    .NPredicateBuilderEFWhere(query)
                    .ToListAsync();
            }

            Assert.AreEqual(3, results.Count);
        }
    }
}