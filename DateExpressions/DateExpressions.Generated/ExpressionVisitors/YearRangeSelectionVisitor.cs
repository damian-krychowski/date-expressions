using DateExpressions.Generated.Ordinals;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class YearRangeSelectionVisitor
    {
        //todo should be more flexible, like from 2nd to 3rd year
        public IPeriodsSelector<YearPeriod> Visit(ExpressionParser.YearrangeselectionContext context)
        {
            return new RangePeriodsSelector<YearPeriod>(
                getIndexOfPeriod: year => year.Year,
                @from: int.Parse(context.@from.Text),
                to: int.Parse(context.to.Text));
        }
    }
}