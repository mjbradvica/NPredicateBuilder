// <copyright file="TestHelper.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

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
        /// Resets the database.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task ClearTables()
        {
            await using (var context = new TestContext())
            {
                await context.Database.EnsureDeletedAsync();

                await context.Database.EnsureCreatedAsync();
            }
        }
    }
}