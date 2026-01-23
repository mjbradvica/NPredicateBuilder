// <copyright file="NPredicateBuilderWhereTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

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
        public void WhereIEnumerableFiltersCorrectly()
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
        public void WhereQueryableFiltersCorrectly()
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
        public void MultipleAndFiltersIEnumerableFiltersCorrectly()
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
        public void MultipleAndFiltersIQueryableFiltersCorrectly()
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
        public void CombinedAndOrFiltersIEnumerableFiltersCorrectly()
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

            Assert.HasCount(3, result);
        }

        /// <summary>
        /// Ensure compound filters for IQueryable are correct.
        /// </summary>
        [TestMethod]
        public void CombinedAndOrFiltersIQueryableFiltersCorrectly()
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

            Assert.HasCount(3, result);
        }

        /// <summary>
        /// Ensures filters for IEnumerable are correct.
        /// </summary>
        [TestMethod]
        public void AppendedFiltersIEnumerableFiltersCorrectly()
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

            Assert.HasCount(3, result);
        }

        /// <summary>
        /// Ensures filters for IQueryable are correct.
        /// </summary>
        [TestMethod]
        public void AppendedFiltersIQueryableFiltersCorrectly()
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

            Assert.HasCount(3, result);
        }

        /// <summary>
        /// Ensures compound And filters are correct.
        /// </summary>
        [TestMethod]
        public void CompoundQueryIEnumerableFiltersCorrectly()
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

            Assert.HasCount(1, result);
        }

        /// <summary>
        /// Ensures a new query on null expression is added.
        /// </summary>
        [TestMethod]
        public void OrCriteriaFirstNullExpressionAddsNewExpression()
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

            Assert.HasCount(2, result);
        }

        /// <summary>
        /// Compound AND query with invalid current only uses next.
        /// </summary>
        [TestMethod]
        public void AndNullExpressionValidNewExpressionUsesNewExpression()
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

            Assert.HasCount(1, result);
        }

        /// <summary>
        /// Compound OR query with invalid current only uses next expression.
        /// </summary>
        [TestMethod]
        public void OrNullExpressionValidNewExpressionUsesNewExpression()
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

            Assert.HasCount(1, result);
        }
    }
}