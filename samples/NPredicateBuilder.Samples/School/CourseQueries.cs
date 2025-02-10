// <copyright file="CourseQueries.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder.Samples.School
{
    /// <summary>
    /// Sample query object for the <see cref="Course"/> class.
    /// </summary>
    internal class CourseQueries : BaseQuery<Course>
    {
        /// <summary>
        /// Checks to see if a course has a requirement that must be taken before.
        /// </summary>
        /// <returns>The query object.</returns>
        public CourseQueries OrIsPrerequisite()
        {
            AddOrCriteria(course => course.HasPrerequisite);

            return this;
        }
    }
}