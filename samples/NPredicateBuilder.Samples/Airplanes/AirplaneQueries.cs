// <copyright file="AirplaneQueries.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder.Samples.Airplanes
{
    /// <summary>
    /// Sample queries.
    /// </summary>
    public class AirplaneQueries : BaseQuery<Airplane>
    {
        /// <summary>
        /// Sample query.
        /// </summary>
        /// <returns>An instance of <see cref="AirplaneQueries"/>.</returns>
        public AirplaneQueries IsBoeing()
        {
            AddAndCriteria(airplane => airplane.Manufacturer == "Boeing");

            return this;
        }

        /// <summary>
        /// Sample query.
        /// </summary>
        /// <returns>An instance of <see cref="AirplaneQueries"/>.</returns>
        public AirplaneQueries IsAirbus()
        {
            AddAndCriteria(airplane => airplane.Manufacturer == "Airbus");

            return this;
        }

        /// <summary>
        /// Sample query.
        /// </summary>
        /// <returns>An instance of <see cref="AirplaneQueries"/>.</returns>
        public AirplaneQueries AndIsWideBody()
        {
            AddAndCriteria(airplane => airplane.Model == "787-9" || airplane.Model == "A330-9");

            return this;
        }

        /// <summary>
        /// Sample query.
        /// </summary>
        /// <returns>An instance of <see cref="AirplaneQueries"/>.</returns>
        public AirplaneQueries AndIsNarrowBody()
        {
            AddAndCriteria(airplane => airplane.Model == "737-8" || airplane.Model == "A320");

            return this;
        }
    }
}