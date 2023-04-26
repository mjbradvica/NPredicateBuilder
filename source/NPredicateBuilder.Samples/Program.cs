﻿namespace NPredicateBuilder.Samples
{
    using Airplanes;
    using EF;
    using Flights;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            // await AddData();

            // await SimpleQuery();

            await QueryAndOrder();
        }

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