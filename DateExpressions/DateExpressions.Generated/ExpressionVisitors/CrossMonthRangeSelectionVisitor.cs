using DateExpressions.Generated.DateGenerators;
using DateExpressions.Generated.MonthlySelections;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class CrossMonthRangeSelectionVisitor
    {
        private readonly PointInMonthVisitor _pointInMonthVisitor;

        public CrossMonthRangeSelectionVisitor(PointInMonthVisitor pointInMonthVisitor)
        {
            _pointInMonthVisitor = pointInMonthVisitor;
        }

        public CrossMonthRangeSelection Visit(ExpressionParser.CrossmonthrangeselectionContext context)
        {
            return new CrossMonthRangeSelection(
                @from: _pointInMonthVisitor.Visit(context.@from),
                to: _pointInMonthVisitor.Visit(context.to));
        }
    }
}