// <copyright file="FlightQueries.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NPredicateBuilder.Samples.Airplanes;

namespace NPredicateBuilder.Samples.Flights
{
    /// <summary>
    /// A sample base query for a <see cref="Flight"/>.
    /// </summary>
    public class FlightQueries : BaseQuery<Flight>
    {
        /// <summary>
        /// Sample query.
        /// </summary>
        /// <returns>An instance of <see cref="FlightQueries"/>.</returns>
        public FlightQueries DepartsToday()
        {
            AddAndCriteria(flight => flight.Departure.DayOfYear == DateTime.UtcNow.DayOfYear);

            return this;
        }

        /// <summary>
        /// Sample query.
        /// </summary>
        /// <param name="airplane">A <see cref="Airplane"/> entity.</param>
        /// <returns>An instance of the <see cref="FlightQueries"/>.</returns>
        public FlightQueries HasAirplane(Airplane airplane)
        {
            AddAndCriteria(flight => flight.Airplane.Id == airplane.Id);

            return this;
        }
    }
}