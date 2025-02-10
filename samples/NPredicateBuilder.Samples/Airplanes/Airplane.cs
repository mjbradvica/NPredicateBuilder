// <copyright file="Airplane.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder.Samples.Airplanes
{
    /// <summary>
    /// Sample entity.
    /// </summary>
    public class Airplane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Airplane"/> class.
        /// </summary>
        /// <param name="manufacturer">Manufacturer.</param>
        /// <param name="model">Model.</param>
        /// <param name="range">Range.</param>
        public Airplane(string manufacturer, string model, int range)
            : this()
        {
            Id = Guid.NewGuid();
            Manufacturer = manufacturer;
            Model = model;
            Range = range;
        }

        private Airplane()
        {
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Manufacturer.
        /// </summary>
        public string Manufacturer { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Model.
        /// </summary>
        public string Model { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Range.
        /// </summary>
        public int Range { get; set; }

        /// <summary>
        /// Creates a string representation of the airplane state.
        /// </summary>
        /// <returns>String to output.</returns>
        public override string ToString()
        {
            return $"Id: {Id} Manufacturer: {Manufacturer} Model: {Model} Range: {Range}";
        }
    }
}