using System;
using System.Linq;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class MonthsSelectorVisitor
    {
        private readonly SingleMonthSelectorVisitor _singleMonthSelectorVisitor = new SingleMonthSelectorVisitor();
        private readonly OrdinalVisitor _ordinalVisitor = new OrdinalVisitor();
        private readonly MonthRangeSelectionVisitor _monthRangeSelectionVisitor = new MonthRangeSelectionVisitor();
        
        public IPeriodsSelector<MonthPeriod> Visit(ExpressionParser.MonthsselectorsContext context)
        {
            var monthGroups = context.monthsselector();

            if (monthGroups != null && monthGroups.Any())
                return new PeriodsSelectorComposite<MonthPeriod>(monthGroups
                    .Select(Visit)
                    .ToArray());

            throw new InvalidOperationException(
                "Unexpected monthselectors token");
        }

        public IPeriodsSelector<MonthPeriod> Visit(ExpressionParser.MonthsselectorContext context)
        {
            if (context.EVERY() != null)
                return new All<MonthPeriod>();

            if (context.singlemonthselector() != null)
                return new SingleToManyAdapter<MonthPeriod>(
                    _singleMonthSelectorVisitor.Visit(context.singlemonthselector()));

            if (context.MONTH() != null && context.ordinals() != null)
                return new OrdinalPeriodsSelector<MonthPeriod>(
                    ordinal: _ordinalVisitor.Visit(context.ordinals()));

            if (context.monthrangeselection() != null)
                return _monthRangeSelectionVisitor.Visit(context.monthrangeselection());

            throw new InvalidOperationException(
                "Unexpected monthselector token");
        }
    }
}