using System.Linq;
using DateExpressions.Generated.DateGenerators;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class YearlySelectionVisitor
    {
        private readonly YearSelectorVisitor _yearSelectorVisitor = new YearSelectorVisitor();
        private readonly MonthlySelectionVisitor _monthlySelectionVisitor = new MonthlySelectionVisitor();
        
        public YearlySelection[] Visit(ExpressionParser.YearlyselectionsContext context)
        {
            return context
                .yearlyselection()
                .Select(Visit)
                .ToArray();
        }

        public YearlySelection Visit(ExpressionParser.YearlyselectionContext context)
        {
            return new YearlySelection(
                yearsSelector: context.yearselectors() != null
                    ? Option<IPeriodsSelector<YearPeriod>>.Some(
                        value: _yearSelectorVisitor.Visit(context.yearselectors()))
                    : Option<IPeriodsSelector<YearPeriod>>.None,
                monthlySelections: _monthlySelectionVisitor.Visit(context.monthlyselections()));
        }
    }
}