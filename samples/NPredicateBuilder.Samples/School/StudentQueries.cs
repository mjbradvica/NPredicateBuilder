// <copyright file="StudentQueries.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder.Samples.School
{
    /// <summary>
    /// Sample class for <see cref="Student"/> queries.
    /// </summary>
    internal class StudentQueries : BaseQuery<Student>
    {
        /// <summary>
        /// Returns all courses for a student that match a department.
        /// </summary>
        /// <param name="department">The <see cref="Department"/> to match against.</param>
        /// <returns>The builder object.</returns>
        public StudentQueries AndCoursesFromDepartment(Department department)
        {
            AddAndCriteria(student => student.Courses.Any(studentCourse => studentCourse.Course.Department == department));

            return this;
        }

        /// <summary>
        /// Checks if a student is currently enrolled in a course by identifier.
        /// </summary>
        /// <param name="id">The course identifier.</param>
        /// <returns>The builder object.</returns>
        public StudentQueries IsEnrolledInCourse(Guid id)
        {
            AddAndCriteria(student => student.Courses.Any(course => course.Id == id));

            return this;
        }
    }
}