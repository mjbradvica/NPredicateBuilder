// <copyright file="BaseIntegrationTest.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace NPredicateBuilder.Tests
{
    /// <inheritdoc />
    public abstract class BaseIntegrationTest : IDisposable
    {
        private readonly DbConnection _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIntegrationTest"/> class.
        /// </summary>
        protected BaseIntegrationTest()
        {
            _connection = new SqliteConnection("DataSource=myshareddb;mode=memory;cache=shared");
            _connection.Open();

            ContextOptions = new DbContextOptionsBuilder().UseSqlite(_connection).Options;

            using (var context = new TestContext(ContextOptions))
            {
                if (context.Database.CanConnect())
                {
                    context.Database.EnsureDeleted();

                    context.Database.EnsureCreated();
                }
            }
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        protected DbContextOptions ContextOptions { get; }

        /// <inheritdoc/>
        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}