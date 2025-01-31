// <copyright file="TestContext.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

#if NETFRAMEWORK
using System;
using System.Data.Entity;

namespace NPredicateBuilder.Tests
{
#else
using Microsoft.EntityFrameworkCore;
using System;

namespace NPredicateBuilder.Tests
{
#endif

    /// <summary>
    /// EF Context for testing.
    /// </summary>
    public sealed class TestContext : DbContext
    {
#if NETFRAMEWORK
        /// <summary>
        /// Initializes a new instance of the <see cref="TestContext"/> class.
        /// </summary>
        public TestContext()
            : base(Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING") ??
                   "Server=.\\SQLExpress;Database=NPredicateBuilder;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true")
        {
        }
#else
        /// <summary>
        /// Initializes a new instance of the <see cref="TestContext"/> class.
        /// </summary>
        public TestContext()
            : base(new DbContextOptionsBuilder().UseSqlServer(Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING") ??
                                                              "Server=.\\SQLExpress;Database=NPredicateBuilder;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true").Options)
        {
            Database.EnsureCreated();
        }
#endif

        /// <summary>
        /// Gets or sets a DbSet for a Customer table.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
    }
}