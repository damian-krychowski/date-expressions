using System;
using System.Linq;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.MonthlySelections;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class MonthlySelectionVisitor
    {
        private readonly MonthsSelectorVisitor _monthsSelectorVisitor = new MonthsSelectorVisitor();
        private readonly WeeklySelectionVisitor _weeklySelectionVisitor = new WeeklySelectionVisitor();
        private readonly CrossMonthRangeSelectionVisitor _crossMonthRangeSelectionVisitor = new CrossMonthRangeSelectionVisitor();
        
        public ISelection[] Visit(ExpressionParser.MonthlyselectionsContext context)
        {
            return context
                .monthlyselection()
                .Select(Visit)
                .ToArray();
        }

        public ISelection Visit(ExpressionParser.MonthlyselectionContext context)
        {
            if (context.weeklyselections() != null)
                return new MonthlySelection(
                    monthsSelector: context.monthsselectors() != null
                        ? Option<IPeriodsSelector<MonthPeriod>>.Some(
                            value: _monthsSelectorVisitor.Visit(context.monthsselectors()))
                        : Option<IPeriodsSelector<MonthPeriod>>.None,
                    weeklySelections: _weeklySelectionVisitor.Visit(context.weeklyselections()));

            if (context.crossmonthrangeselection() != null)
                return _crossMonthRangeSelectionVisitor.Visit(context.crossmonthrangeselection());

            throw new InvalidOperationException(
                "Unexpected monthlyselection token");
        }
    }
}