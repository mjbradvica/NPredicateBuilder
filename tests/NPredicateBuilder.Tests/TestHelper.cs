﻿// <copyright file="TestHelper.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
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
    }
}