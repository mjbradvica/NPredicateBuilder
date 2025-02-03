// <copyright file="TestContext.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;

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
        /// <param name="options">The context options class.</param>
        public TestContext(DbContextOptions options)
            : base(options)
        {
            Customers = Set<Customer>();
        }

        /// <summary>
        /// Gets a DbSet for a Customer table.
        /// </summary>
        public DbSet<Customer> Customers { get; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Customer>()
                .Property(customer => customer.Id)
                .ValueGeneratedNever();
        }
    }
}