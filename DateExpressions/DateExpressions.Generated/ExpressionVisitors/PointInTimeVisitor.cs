using DateExpressions.Generated.DaySelectors;
using DateExpressions.Generated.TimeSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class PointInTimeVisitor
    {
        private readonly OrdinalVisitor _ordinalVisitor = new OrdinalVisitor();
        private readonly DayOfWeekVisitor _dayOfWeekVisitor = new DayOfWeekVisitor();
        
        public PointInTime Visit(ExpressionParser.PointintimeContext context)
        {
            return new PointInTime(
                ordinal: _ordinalVisitor.Visit(context.ordinal()),
                daySelector: context.dayofweek() != null
                    ? _dayOfWeekVisitor.Visit(context.dayofweek())
                    : (IDaySelector) new All());
        }
    }
}