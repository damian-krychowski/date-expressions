using System;
using System.Collections.Generic;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Infrastructure;

namespace DateExpressions.Generated.Periods
{
    internal class MonthsBuilder
    {
        public static IEnumerable<MonthPeriod> Build(Date from, Date to)
        {
            if (from.IsGreaterThan(to))
            {
                throw new ArgumentOutOfRangeException(nameof(from),
                    $"{nameof(from)} ({from}) cannot be greater than {nameof(to)} ({to})");
            }

            var currentMonth = new MonthPeriod(from.Year, from.Month);
            var lastMonth = new MonthPeriod(to.Year, to.Month);

            do
            {
                yield return currentMonth;
                currentMonth = currentMonth.Next();

            } while (currentMonth.IsLessOrEqualTo(lastMonth));
        }
    }
}