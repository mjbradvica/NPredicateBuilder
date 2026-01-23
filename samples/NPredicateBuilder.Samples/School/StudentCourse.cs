// <copyright file="StudentCourse.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder.Samples.School
{
    /// <summary>
    /// Sample class for a course taken by a student.
    /// </summary>
    internal sealed class StudentCourse
    {
        /// <summary>
        /// Gets or sets the student course identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the course for the linking table.
        /// </summary>
        public Course Course { get; set; } = Course.EmptyCourse();
    }
}