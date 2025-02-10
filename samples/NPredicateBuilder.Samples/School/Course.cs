// <copyright file="Course.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder.Samples.School
{
    /// <summary>
    /// Sample class for a school course.
    /// </summary>
    internal class Course
    {
        /// <summary>
        /// Gets or sets the course identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Department the course belongs too.
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the course can be taken independently.
        /// </summary>
        public bool HasPrerequisite { get; set; }

        /// <summary>
        /// Empty version of the <see cref="Course"/> object.
        /// </summary>
        /// <returns>An empty instance of the <see cref="Course"/> class.</returns>
        public static Course EmptyCourse()
        {
            return new Course();
        }
    }
}