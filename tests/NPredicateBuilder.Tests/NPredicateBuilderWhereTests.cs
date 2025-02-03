// <copyright file="NPredicateBuilderWhereTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPredicateBuilder.EF;

namespace NPredicateBuilder.Tests
{
    /// <summary>
    /// Tests where filters.
    /// </summary>
    [TestClass]
    public class NPredicateBuilderWhereTests
    {
        private IEnumerable<Customer> _customers;

        /// <summary>
        /// Initializes a new instance of the <see cref="NPredicateBuilderWhereTests"/> class.
        /// </summary>
        public NPredicateBuilderWhereTests()
        {
            _customers = new List<Customer>();
        }

        /// <summary>
        /// Ensures where filters for IEnumerable are correct.
        /// </summary>
        [TestMethod]
        public void Where_IEnumerable_FiltersCorrectly()
        {
            _customers = new List<Customer>
            {
                TestHelper.Billy(),
                TestHelper.Bobby(),
            };

            var query = new CustomerTestQuery().AndNameIsBobby();

            var result = _customers.NPredicateBuilderWhere(query);

            Assert.AreEqual("Bobby", result.Single().Name);
        }

        /// <summary>
        /// Ensure where filters for IQueryable are correct.
        /// </summary>
        [TestMethod]
        public void Where_Queryable_FiltersCorrectly()
        {
            _customers = new List<Customer>
            {
                TestHelper.Billy(),
                TestHelper.Bobby(),
            };

            var query = new CustomerTestQuery().AndNameIsBobby();

            var result = _customers.AsQueryable().NPredicateBuilderEFWhere(query);

            Assert.AreEqual("Bobby", result.Single().Name);
        }

        /// <summary>
        /// Ensure filters for IEnumerable are correct.
        /// </summary>
        [TestMethod]
        public void MultipleAndFilters_IEnumerable_FiltersCorrectly()
        {
            var correctCustomer = new Customer(Guid.NewGuid(), "Billy", 10);

            _customers = new List<Customer>
            {
                correctCustomer, new Customer(Guid.NewGuid(), "Billy", 5), TestHelper.Bobby(),
            };

            var query = new CustomerTestQuery()
                .AndNameIsBilly().AndAgeIsOverSix();

            var result = _customers
                .NPredicateBuilderWhere(query)
                .ToList();

            Assert.AreEqual(correctCustomer.Name, result.Single().Name);
            Assert.AreEqual(correctCustomer.Age, result.Single().Age);
        }

        /// <summary>
        /// Ensures compound filter for IQueryable are correct.
        /// </summary>
        [TestMethod]
        public void MultipleAndFilters_IQueryable_FiltersCorrectly()
        {
            var correctCustomer = new Customer(Guid.NewGuid(), "Billy", 10);

            _customers = new List<Customer>
            {
                correctCustomer, new Customer(Guid.NewGuid(), "Billy", 5), TestHelper.Bobby(),
            };

            var query = new CustomerTestQuery()
                .AndNameIsBilly().AndAgeIsOverSix();

            var result = _customers.AsQueryable()
                .NPredicateBuilderEFWhere(query)
                .ToList();

            Assert.AreEqual(correctCustomer.Name, result.Single().Name);
            Assert.AreEqual(correctCustomer.Age, result.Single().Age);
        }

        /// <summary>
        /// Ensures compound filters for IEnumerable are correct.
        /// </summary>
        [TestMethod]
        public void CombinedAndOrFilters_IEnumerable_FiltersCorrectly()
        {
            _customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Billy", 5),
                new Customer(Guid.NewGuid(), "Billy", 25),
                new Customer(Guid.NewGuid(), "Bobby", 5),
                new Customer(Guid.NewGuid(), "Bobby", 25),
            };

            var query = new CustomerTestQuery()
                .AndNameIsBilly().OrAgeIsOverTwenty();

            var result = _customers
                .NPredicateBuilderWhere(query)
                .ToList();

            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        /// Ensure compound filters for IQueryable are correct.
        /// </summary>
        [TestMethod]
        public void CombinedAndOrFilters_IQueryable_FiltersCorrectly()
        {
            _customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Billy", 5),
                new Customer(Guid.NewGuid(), "Billy", 25),
                new Customer(Guid.NewGuid(), "Bobby", 5),
                new Customer(Guid.NewGuid(), "Bobby", 25),
            };

            var query = new CustomerTestQuery()
                .AndNameIsBilly().OrAgeIsOverTwenty();

            var result = _customers.AsQueryable()
                .NPredicateBuilderEFWhere(query)
                .ToList();

            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        /// Ensures filters for IEnumerable are correct.
        /// </summary>
        [TestMethod]
        public void AppendedFilters_IEnumerable_FiltersCorrectly()
        {
            _customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Billy", 5),
                new Customer(Guid.NewGuid(), "Billy", 25),
                new Customer(Guid.NewGuid(), "Bobby", 5),
                new Customer(Guid.NewGuid(), "Bobby", 25),
            };

            var query = new CustomerTestQuery()
                .AndNameIsBilly().AndAgeIsOverSix()
                .Or(new CustomerTestQuery().AndNameIsBobby());

            var result = _customers
                .NPredicateBuilderWhere(query)
                .ToList();

            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        /// Ensures filters for IQueryable are correct.
        /// </summary>
        [TestMethod]
        public void AppendedFilters_IQueryable_FiltersCorrectly()
        {
            _customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Billy", 5),
                new Customer(Guid.NewGuid(), "Billy", 25),
                new Customer(Guid.NewGuid(), "Bobby", 5),
                new Customer(Guid.NewGuid(), "Bobby", 25),
            };

            var query = new CustomerTestQuery()
                .AndNameIsBilly().AndAgeIsOverSix()
                .Or(new CustomerTestQuery().AndNameIsBobby());

            var result = _customers.AsQueryable()
                .NPredicateBuilderEFWhere(query)
                .ToList();

            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        /// Ensures compound And filters are correct.
        /// </summary>
        [TestMethod]
        public void CompoundQuery_IEnumerable_FiltersCorrectly()
        {
            _customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Billy", 5),
                new Customer(Guid.NewGuid(), "Billy", 25),
                new Customer(Guid.NewGuid(), "Bobby", 5),
                new Customer(Guid.NewGuid(), "Bobby", 25),
            };

            var query = new CustomerTestQuery()
                .AndAgeIsOverSix()
                .And(new CustomerTestQuery().AndNameIsBobby());

            var result = _customers
                .NPredicateBuilderWhere(query)
                .ToList();

            Assert.AreEqual(1, result.Count);
        }

        /// <summary>
        /// Ensures a new query on null expression is added.
        /// </summary>
        [TestMethod]
        public void OrCriteriaFirst_NullExpression_AddsNewExpression()
        {
            _customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Billy", 5),
                new Customer(Guid.NewGuid(), "Billy", 25),
                new Customer(Guid.NewGuid(), "Bobby", 5),
                new Customer(Guid.NewGuid(), "Bobby", 25),
            };

            var query = new CustomerTestQuery()
                .OrAgeIsOverTwenty();

            var result = _customers
                .NPredicateBuilderWhere(query)
                .ToList();

            Assert.AreEqual(2, result.Count);
        }

        /// <summary>
        /// Compound AND query with invalid current only uses next.
        /// </summary>
        [TestMethod]
        public void And_NullExpression_ValidNewExpression_UsesNewExpression()
        {
            _customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Billy", 5),
                new Customer(Guid.NewGuid(), "Billy", 25),
            };

            var query = new CustomerTestQuery()
                .And(new CustomerTestQuery().AndAgeIsOverSix());

            var result = _customers
                .NPredicateBuilderWhere(query)
                .ToList();

            Assert.AreEqual(1, result.Count);
        }

        /// <summary>
        /// Compound OR query with invalid current only uses next expression.
        /// </summary>
        [TestMethod]
        public void Or_NullExpression_ValidNewExpression_UsesNewExpression()
        {
            _customers = new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Billy", 5),
                new Customer(Guid.NewGuid(), "Billy", 25),
            };

            var query = new CustomerTestQuery()
                .Or(new CustomerTestQuery().AndAgeIsOverSix());

            var result = _customers
                .NPredicateBuilderWhere(query)
                .ToList();

            Assert.AreEqual(1, result.Count);
        }
    }
}