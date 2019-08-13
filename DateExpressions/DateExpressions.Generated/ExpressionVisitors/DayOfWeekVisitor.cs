using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateExpressions.Generated.DaySelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class DayOfWeekVisitor
    {
        public IDaySelector[] Visit(ExpressionParser.DaysofweekContext context)
        {
            var weekDays = context.dayofweek();

            if (weekDays != null && weekDays.Any())
                return weekDays
                    .Select(Visit)
                    .Cast<IDaySelector>()
                    .ToArray();

            throw new InvalidOperationException(
                $"Unexpected daysofweek token.");
        }

        public WeekDay Visit(ExpressionParser.DayofweekContext context)
        {
            if (context.MONDAY() != null)
                return new WeekDay(DayOfWeek.Monday);

            if (context.TUESDAY() != null)
                return new WeekDay(DayOfWeek.Tuesday);

            if (context.WEDNESDAY() != null)
                return new WeekDay(DayOfWeek.Wednesday);

            if (context.THURSDAY() != null)
                return new WeekDay(DayOfWeek.Thursday);

            if (context.FRIDAY() != null)
                return new WeekDay(DayOfWeek.Friday);

            if (context.SATURDAY() != null)
                return new WeekDay(DayOfWeek.Saturday);

            if (context.SUNDAY() != null)
                return new WeekDay(DayOfWeek.Sunday);

            throw new InvalidOperationException(
                $"Unexpected dayofweek token.");
        }
    }
}
