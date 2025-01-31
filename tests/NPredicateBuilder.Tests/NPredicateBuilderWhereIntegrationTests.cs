// <copyright file="NPredicateBuilderWhereIntegrationTests.cs" company="Michael Bradvica LLC">
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
    /// Tests where filters for EF databases.
    /// </summary>
    [TestClass]
    public class NPredicateBuilderWhereIntegrationTests
    {
        /// <summary>
        /// Ensures where filters for databases are correct.
        /// </summary>
        [TestMethod]
        public void Where_DbSet_FiltersCorrectly()
        {
            TestHelper.ClearCustomers();

            var customers = new List<Customer>
            {
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
                var query = new CustomerTestQuery()
                    .AndNameIsBobby();

                var result = context.Customers
                    .NPredicateBuilderEFWhere(query)
                    .ToList();

                Assert.AreEqual("Bobby", result.Single().Name);
            }
        }

        /// <summary>
        /// Ensures multiple filters for databases are correct.
        /// </summary>
        [TestMethod]
        public void MultipleAndFilters_FiltersCorrectly()
        {
            TestHelper.ClearCustomers();

            var correctCustomer = new Customer(Guid.NewGuid(), "Billy", 10);

            var customers = new List<Customer>
            {
                correctCustomer, new Customer(Guid.NewGuid(), "Billy", 5), TestHelper.Bobby(),
            };

            using (var context = new TestContext())
            {
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            using (var context = new TestContext())
            {
                var query = new CustomerTestQuery()
                    .AndNameIsBilly().AndAgeIsOverSix();

                var result = context.Customers
                    .NPredicateBuilderEFWhere(query)
                    .ToList();

                Assert.AreEqual(correctCustomer.Name, result.Single().Name);
                Assert.AreEqual(correctCustomer.Age, result.Single().Age);
            }
        }

        /// <summary>
        /// Ensures compound filters for databases are correct.
        /// </summary>
        [TestMethod]
        public void CombinedAndOrFilters_FiltersCorrectly()
        {
            TestHelper.ClearCustomers();

            var customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Billy", 5),
                new Customer(Guid.NewGuid(), "Billy", 25),
                new Customer(Guid.NewGuid(), "Bobby", 5),
                new Customer(Guid.NewGuid(), "Bobby", 25),
            };

            using (var context = new TestContext())
            {
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            using (var context = new TestContext())
            {
                var query = new CustomerTestQuery()
                    .AndNameIsBilly().OrAgeIsOverTwenty();

                var result = context.Customers
                    .NPredicateBuilderEFWhere(query)
                    .ToList();

                Assert.AreEqual(3, result.Count);
            }
        }

        /// <summary>
        /// Ensures compound filters for databases are correct.
        /// </summary>
        [TestMethod]
        public void AppendedFilters_FiltersCorrectly()
        {
            TestHelper.ClearCustomers();

            var customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Billy", 5),
                new Customer(Guid.NewGuid(), "Billy", 25),
                new Customer(Guid.NewGuid(), "Bobby", 5),
                new Customer(Guid.NewGuid(), "Bobby", 25),
            };

            using (var context = new TestContext())
            {
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            using (var context = new TestContext())
            {
                var query = new CustomerTestQuery()
                    .AndNameIsBilly().AndAgeIsOverSix()
                    .Or(new CustomerTestQuery().AndNameIsBobby());

                var result = context.Customers
                    .NPredicateBuilderEFWhere(query)
                    .ToList();

                Assert.AreEqual(3, result.Count);
            }
        }
    }
}