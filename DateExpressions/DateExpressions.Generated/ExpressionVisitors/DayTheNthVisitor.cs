using DateExpressions.Generated.Ordinals;
using DateExpressions.Generated.TimeSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class DayTheNthVisitor
    {
        private readonly DayOfWeekVisitor _dayOfWeekVisitor = new DayOfWeekVisitor();
        private readonly NumeralVisitor _numeralVisitor = new NumeralVisitor();
        private readonly IOrdinals _ordinals;

        public DayTheNthVisitor(
            IOrdinals ordinals)
        {
            _ordinals = ordinals;
        }

        public DayTheNthSelector Visit(ExpressionParser.DaythenthContext context)
        {
            return new DayTheNthSelector(
                weekDay: _dayOfWeekVisitor.Visit(context.dayofweek()),
                nth: _numeralVisitor.Visit(context.numeral()),
                ordinals: _ordinals);
        }
    }
}