﻿using System.Linq;

namespace NPredicateBuilder.Aggregation
{
    internal class DoubleAverage : ISingleFinalizer<double, double>
    {
        public double Finalize(IQueryable<double> queryable) => queryable.Average();
    }
}
