// <copyright file="TestContext.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using System;

namespace NPredicateBuilder.Tests
{
    /// <summary>
    /// EF Context for testing.
    /// </summary>
    public sealed class TestContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestContext"/> class.
        /// </summary>
        public TestContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets a DbSet for a Customer table.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Configures the database connection.
        /// </summary>
        /// <param name="optionsBuilder">Allow further options for database configuration.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING") ??
                                   "Server=.\\SQLExpress;Database=NPredicateBuilder;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}