// <copyright file="TestHelper.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;

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
            await using (var context = new TestContext(GetOptions()))
            {
                await context.Database.EnsureDeletedAsync();

                await context.Database.EnsureCreatedAsync();
            }
        }

        /// <summary>
        /// Get the db options.
        /// </summary>
        /// <returns>A context options.</returns>
        public static DbContextOptions GetOptions()
        {
            var connection = Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING") ??
                             "Server=.\\SQLExpress;Database=NPredicateBuilder;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true";

            return new DbContextOptionsBuilder().UseSqlServer(connection).Options;
        }
    }
}