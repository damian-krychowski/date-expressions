using System.Linq;
using DateExpressions.Generated.DateGenerators;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Ordinals;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class WeeklySelectionVisitor
    {
        private readonly WeekSelectorsVisitor _weekSelectorsVisitor = new WeekSelectorsVisitor();
        private readonly TimeSelectionVisitor _timeSelectionVisitor = new TimeSelectionVisitor();
        
        public WeeklySelection[] Visit(ExpressionParser.WeeklyselectionsContext context)
        {
            return context
                .weeklyselection()
                .Select(Visit)
                .ToArray();
        }

        public WeeklySelection Visit(ExpressionParser.WeeklyselectionContext context)
        {
            return new WeeklySelection(
                weeksSelector: context.weekselectors() != null
                    ? Option<IPeriodsSelector<WeekPeriod>>.Some(
                        value: _weekSelectorsVisitor.Visit(context.weekselectors()))
                    : Option<IPeriodsSelector<WeekPeriod>>.None,
                timeSelector: _timeSelectionVisitor.Visit(context.timeselections()));
        }
    }
}