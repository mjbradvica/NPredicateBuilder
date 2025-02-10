// <copyright file="Program.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NPredicateBuilder.EF;
using NPredicateBuilder.Samples.Airplanes;
using NPredicateBuilder.Samples.Flights;

namespace NPredicateBuilder.Samples
{
    /// <summary>
    /// Sample console application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Sample main function.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task Main()
        {
            // await AddData();
            // await SimpleQuery();
            // await QueryAndOrder();
            // await ChainedQuery();
            // await CompoundQuery();
            await CompoundQueryAndMultipleOrder();
        }

        /// <summary>
        /// Sample query for a simple where statement.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task SimpleQuery()
        {
            var query = new AirplaneQueries().IsBoeing();

            await using (var context = new SampleContext())
            {
                var result = await context.Airplanes
                    .NPredicateBuilderEFWhere(query)
                    .ToListAsync();

                result.ForEach(Console.WriteLine);
            }
        }

        /// <summary>
        /// Sample query and order.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task QueryAndOrder()
        {
            var query = new AirplaneQueries().IsBoeing();

            var order = new AirplaneOrders().OrderByManufacturer().ThenByModel();

            await using (var context = new SampleContext())
            {
                var result = await context.Airplanes
                    .NPredicateBuilderEFWhere(query)
                    .NPredicateBuilderEFOrder(order)
                    .ToListAsync();

                result.ForEach(Console.WriteLine);
            }
        }

        /// <summary>
        /// Sample chained query.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task ChainedQuery()
        {
            var query = new AirplaneQueries().IsBoeing().AndIsWideBody();

            await using (var context = new SampleContext())
            {
                var result = await context.Airplanes
                    .NPredicateBuilderEFWhere(query)
                    .ToListAsync();

                result.ForEach(Console.WriteLine);
            }
        }

        /// <summary>
        /// Sample compound query.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task CompoundQuery()
        {
            var query = new AirplaneQueries()
                .IsBoeing().AndIsWideBody()
                .Or(new AirplaneQueries().IsAirbus().AndIsNarrowBody());

            await using (var context = new SampleContext())
            {
                var result = await context.Airplanes
                    .NPredicateBuilderEFWhere(query)
                    .ToListAsync();

                result.ForEach(Console.WriteLine);
            }
        }

        /// <summary>
        /// Sample compound query with ordering.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task CompoundQueryAndMultipleOrder()
        {
            var query = new AirplaneQueries()
                .IsBoeing().AndIsWideBody()
                .Or(new AirplaneQueries().AndIsNarrowBody());

            var order = new AirplaneOrders()
                .ByModelDescending()
                .ThenByManufacturerDescending();

            await using (var context = new SampleContext())
            {
                var result = await context.Airplanes
                    .NPredicateBuilderEFWhere(query)
                    .NPredicateBuilderEFOrder(order)
                    .ToListAsync();

                result.ForEach(Console.WriteLine);
            }
        }

        /// <summary>
        /// Sample data to query and order against.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task AddData()
        {
            await using (var context = new SampleContext())
            {
                var first = new Airplane("Boeing", "737-8", 3500);
                var second = new Airplane("Boeing", "737-8", 3500);
                var third = new Airplane("Boeing", "787-9", 7000);
                var fourth = new Airplane("Boeing", "787-9", 7000);
                var fifth = new Airplane("Airbus", "A320", 3400);
                var sixth = new Airplane("Airbus", "A320", 3400);
                var seventh = new Airplane("Airbus", "A330-9", 6700);
                var eighth = new Airplane("Airbus", "A330-9", 6700);

                await context.Flights.AddRangeAsync(new List<Flight>
                {
                    new Flight(first),
                    new Flight(first),
                    new Flight(second),
                    new Flight(second),
                    new Flight(third),
                    new Flight(third),
                    new Flight(fourth),
                    new Flight(fourth),
                    new Flight(fifth),
                    new Flight(fifth),
                    new Flight(sixth),
                    new Flight(sixth),
                    new Flight(seventh),
                    new Flight(seventh),
                    new Flight(eighth),
                    new Flight(eighth),
                });

                await context.SaveChangesAsync();
            }
        }
    }
}