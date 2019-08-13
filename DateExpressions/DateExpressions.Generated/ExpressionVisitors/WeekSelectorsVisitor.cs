using System;
using DateExpressions.Generated.DaySelectors;
using DateExpressions.Generated.Ordinals;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class WeekSelectorsVisitor
    {
        private readonly OrdinalVisitor _ordinalVisitor;

        public WeekSelectorsVisitor(OrdinalVisitor ordinalVisitor)
        {
            _ordinalVisitor = ordinalVisitor;
        }

        public IPeriodsSelector<WeekPeriod> Visit(ExpressionParser.WeekselectorsContext context)
        {
            if (context.EVERY() != null)
                return new All<WeekPeriod>();

            if (context.ordinals() != null)
                return new OrdinalPeriodsSelector<WeekPeriod>(
                    ordinal: _ordinalVisitor.Visit(context.ordinals()));

            throw new InvalidOperationException(
                "Unexpected weekselectors token");
        }
    }
}