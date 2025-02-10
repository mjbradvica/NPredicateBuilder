// <copyright file="AirplaneOrders.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NPredicateBuilder.Samples.Airplanes
{
    /// <summary>
    /// Sample order for a <see cref="Airplane"/>.
    /// </summary>
    public class AirplaneOrders : BaseOrder<Airplane>
    {
        /// <summary>
        /// Sample order.
        /// </summary>
        /// <returns>An instance of <see cref="AirplaneOrders"/>.</returns>
        public AirplaneOrders OrderByManufacturer()
        {
            OrderBy(airplane => airplane.Manufacturer);

            return this;
        }

        /// <summary>
        /// Sample order.
        /// </summary>
        /// <returns>An instance of <see cref="AirplaneOrders"/>.</returns>
        public AirplaneOrders ThenByModel()
        {
            ThenBy(airplane => airplane.Model);

            return this;
        }

        /// <summary>
        /// Sample order.
        /// </summary>
        /// <returns>An instance of <see cref="AirplaneOrders"/>.</returns>
        public AirplaneOrders ByModelDescending()
        {
            OrderByDescending(x => x.Model);

            return this;
        }

        /// <summary>
        /// Sample order.
        /// </summary>
        /// <returns>An instance of <see cref="AirplaneOrders"/>.</returns>
        public AirplaneOrders ThenByManufacturerDescending()
        {
            ThenByDescending(x => x.Manufacturer);

            return this;
        }
    }
}