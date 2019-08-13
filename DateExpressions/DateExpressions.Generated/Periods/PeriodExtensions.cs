using System.Collections.Generic;
using DateExpressions.Generated.Dates;

namespace DateExpressions.Generated.Periods
{
    internal static class PeriodExtensions
    {
        public static IEnumerable<Date> Days(this IPeriod period) 
            => Calendar.Days(period.From, period.To);

        public static IEnumerable<WeekPeriod> Weeks(this IPeriod period)
            => WeeksBuilder.Build(period.From, period.To);

        public static IEnumerable<MonthPeriod> Months(this IPeriod period)
            => MonthsBuilder.Build(period.From, period.To);

        public static IEnumerable<YearPeriod> Years(this IPeriod period)
            => YearsBuilder.Build(period.From, period.To);
    }
}