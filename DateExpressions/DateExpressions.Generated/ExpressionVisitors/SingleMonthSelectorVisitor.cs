using System;
using DateExpressions.Generated.Ordinals;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class SingleMonthSelectorVisitor
    {
        private readonly MonthVisitor _monthVisitor;
        private readonly OrdinalVisitor _ordinalVisitor;

        public SingleMonthSelectorVisitor(
            MonthVisitor monthVisitor,
            OrdinalVisitor ordinalVisitor)
        {
            _monthVisitor = monthVisitor;
            _ordinalVisitor = ordinalVisitor;
        }

        public IPeriodSelector<MonthPeriod> Visit(ExpressionParser.SinglemonthselectorContext context)
        {
            if (context.month() != null)
                return new NthPeriodSelector<MonthPeriod, int>(
                    getIndexOfPeriod: month => month.Month,
                    index: _monthVisitor.Visit(context.month()));

            if (context.ordinal() != null)
                return new OrdinalPeriodSelector<MonthPeriod>(
                    ordinal: _ordinalVisitor.Visit(context.ordinal()));

            throw new InvalidOperationException(
                "Unexpected singlemonthselector token");
        }
    }
}