// <copyright file="TestHelper.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;

namespace NPredicateBuilder.Tests
{
    /// <summary>
    /// Helper class for tests.
    /// </summary>
    public static class TestHelper
    {
        /// <summary>
        /// Creates a new test subject.
        /// </summary>
        /// <returns>A test customer.</returns>
        public static Customer Billy()
        {
            return new Customer(Guid.NewGuid(), "Billy", 20);
        }

        /// <summary>
        /// Creates a new test subject.
        /// </summary>
        /// <returns>A test customer.</returns>
        public static Customer Bobby()
        {
            return new Customer(Guid.NewGuid(), "Bobby", 30);
        }

        /// <summary>
        /// Clears the customer table.
        /// </summary>
        public static void ClearCustomers()
        {
            using (var context = new TestContext())
            {
                var customers = context.Customers.ToList();

                if (customers.Any())
                {
                    context.Customers.RemoveRange(customers);
                    context.SaveChanges();
                }
            }
        }
    }
}