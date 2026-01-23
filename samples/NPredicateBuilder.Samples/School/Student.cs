// <copyright file="Student.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder.Samples.School
{
    /// <summary>
    /// Sample class for a student.
    /// </summary>
    internal sealed class Student
    {
        /// <summary>
        /// Gets or sets the student identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the student name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the courses the student is enrolled in.
        /// </summary>
        public ICollection<StudentCourse> Courses { get; set; } = new List<StudentCourse>();
    }
}