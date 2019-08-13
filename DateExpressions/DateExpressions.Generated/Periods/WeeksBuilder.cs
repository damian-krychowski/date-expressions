using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Infrastructure;

[assembly: InternalsVisibleTo("DateExpressions.Test")]
namespace DateExpressions.Generated.Periods
{
    internal class WeeksBuilder 
    {
        public static IEnumerable<WeekPeriod> Build(Date from, Date to)
        {
            if (from.IsGreaterThan(to))
            {
                throw new ArgumentOutOfRangeException(nameof(from),
                    $"{nameof(from)} ({from}) cannot be greater than {nameof(to)} ({to})");
            }

            return Calendar
                .Days(from, to)
                .GroupBy(Calendar.GetFirstMondayBefore)
                .Select(@group => new WeekPeriod(group.Key));
        }
    }
}