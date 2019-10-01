using DateExpressions.Generated.DaySelectors;
using DateExpressions.Generated.MonthlySelections;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class PointInMonthVisitor
    {
        private readonly OrdinalVisitor _ordinalVisitor = new OrdinalVisitor();
        private readonly DayOfWeekVisitor _dayOfWeekVisitor = new DayOfWeekVisitor();
        private readonly SingleMonthSelectorVisitor _singleMonthSelectorVisitor = new SingleMonthSelectorVisitor();

        public PointInMonth Visit(ExpressionParser.PointinmonthContext context)
        {
            return new PointInMonth(
                ordinal: _ordinalVisitor.Visit(context.ordinal()),
                daySelector: context.dayofweek() == null
                    ? (IDaySelector) new All()
                    : _dayOfWeekVisitor.Visit(context.dayofweek()),
                monthSelector: _singleMonthSelectorVisitor.Visit(context.singlemonthselector()));
        }
    }
}