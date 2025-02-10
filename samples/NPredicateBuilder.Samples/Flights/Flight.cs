// <copyright file="Flight.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NPredicateBuilder.Samples.Airplanes;

namespace NPredicateBuilder.Samples.Flights
{
    /// <summary>
    /// Sample entity.
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Flight"/> class.
        /// </summary>
        /// <param name="airplane">The airplane for the flight.</param>
        public Flight(Airplane airplane)
            : this()
        {
            Id = Guid.NewGuid();
            Airplane = airplane;
            Departure = DateTime.UtcNow;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Flight"/> class.
        /// </summary>
        public Flight()
        {
            Airplane = default!;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the Airplane navigation property.
        /// </summary>
        public Airplane Airplane { get; private set; }

        /// <summary>
        /// Gets the flight departure.
        /// </summary>
        public DateTime Departure { get; private set; }
    }
}