using DateExpressions.Generated.TimeSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class DayTheNthVisitor
    {
        private readonly DayOfWeekVisitor _dayOfWeekVisitor;
        private readonly NumeralVisitor _numeralVisitor;

        public DayTheNthVisitor(
            DayOfWeekVisitor dayOfWeekVisitor,
            NumeralVisitor numeralVisitor)
        {
            this._dayOfWeekVisitor = dayOfWeekVisitor;
            _numeralVisitor = numeralVisitor;
        }

        public DayTheNthSelector Visit(ExpressionParser.DaythenthContext context)
        {
            return new DayTheNthSelector(
                weekDay: _dayOfWeekVisitor.Visit(context.dayofweek()),
                nth: _numeralVisitor.Visit(context.numeral()));
        }
    }
}