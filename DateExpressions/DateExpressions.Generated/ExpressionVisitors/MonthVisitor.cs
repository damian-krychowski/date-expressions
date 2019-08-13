using System;
using DateExpressions.Generated.DaySelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class MonthVisitor
    {
        public int Visit(ExpressionParser.MonthContext context)
        {
            if (context.JANUARY() != null) return 1;
            if (context.FEBRUARY() != null) return 2;
            if (context.MARCH() != null) return 3;
            if (context.APRIL() != null) return 4;
            if (context.MAY() != null) return 5;
            if (context.JUNE() != null) return 6;
            if (context.JULY() != null) return 7;
            if (context.AUGUST() != null) return 8;
            if (context.SEPTEMBER() != null) return 9;
            if (context.OCTOBER() != null) return 10;
            if (context.NOVEMBER() != null) return 11;
            if (context.DECEMBER() != null) return 12;

            throw new InvalidOperationException(
                $"Unexpected month token.");
        }
    }
}