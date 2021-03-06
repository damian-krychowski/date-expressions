﻿using DateExpressions.Generated.Ordinals;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class MonthRangeSelectionVisitor
    {
        private readonly MonthVisitor _monthVisitor = new MonthVisitor();

        //todo should be more flexible, like from 2nd to 3rd month
        public IPeriodsSelector<MonthPeriod> Visit(ExpressionParser.MonthrangeselectionContext context)
        {
            return new RangePeriodsSelector<MonthPeriod>(
                getIndexOfPeriod: month => month.Month,
                @from: _monthVisitor.Visit(context.@from),
                to: _monthVisitor.Visit(context.to));
        }
    }
}