using DateExpressions.Generated.DaySelectors;
using DateExpressions.Generated.MonthlySelections;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class PointInMonthVisitor
    {
        private readonly OrdinalVisitor _ordinalVisitor;
        private readonly DayOfWeekVisitor _dayOfWeekVisitor;
        private readonly SingleMonthSelectorVisitor _singleMonthSelectorVisitor;

        public PointInMonthVisitor(
            OrdinalVisitor ordinalVisitor,
            DayOfWeekVisitor dayOfWeekVisitor,
            SingleMonthSelectorVisitor singleMonthSelectorVisitor)
        {
            _ordinalVisitor = ordinalVisitor;
            _dayOfWeekVisitor = dayOfWeekVisitor;
            _singleMonthSelectorVisitor = singleMonthSelectorVisitor;
        }

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