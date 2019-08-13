using DateExpressions.Generated.Ordinals;
using DateExpressions.Generated.TimeSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class RangeSelectionVisitor
    {
        private readonly PointInTimeVisitor _pointInTimeVisitor;

        public RangeSelectionVisitor(PointInTimeVisitor pointInTimeVisitor)
        {
            _pointInTimeVisitor = pointInTimeVisitor;
        }

        public RangeSelector Visit(ExpressionParser.RangeselectionContext context)
        {
            return new RangeSelector(
                @from: _pointInTimeVisitor.Visit(context.@from),
                to: _pointInTimeVisitor.Visit(context.to));
        }
    }
}