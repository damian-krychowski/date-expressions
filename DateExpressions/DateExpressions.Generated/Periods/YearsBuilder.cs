using System;
using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Infrastructure;

namespace DateExpressions.Generated.Periods
{
    internal class YearsBuilder
    {
        public static IEnumerable<YearPeriod> Build(Date from, Date to)
        {
            if (from.IsGreaterThan(to))
            {
                throw new ArgumentOutOfRangeException(nameof(from),
                    $"{nameof(from)} ({from}) cannot be greater than {nameof(to)} ({to})");
            }

            return Enumerable
                .Range(@from.Year, to.Year - @from.Year + 1)
                .Select(year => new YearPeriod(year));
        }
    }
}