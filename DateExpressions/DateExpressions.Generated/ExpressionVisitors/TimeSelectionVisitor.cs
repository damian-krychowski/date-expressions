using System;
using System.Linq;
using DateExpressions.Generated.TimeSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class TimeSelectionVisitor
    {
        private readonly RangeSelectionVisitor _rangeSelectionVisitor = new RangeSelectionVisitor();
        private readonly OrdinalVisitor _ordinalVisitor = new OrdinalVisitor();
        private readonly DayOfWeekVisitor _dayOfWeekVisitor = new DayOfWeekVisitor();

        public ITimeSelector Visit(ExpressionParser.TimeselectionsContext context)
        {
            if (context.timeselection() != null)
                return new TimeSelectorComposite(
                    timeSelectors: context.timeselection()
                        .Select(Visit)
                        .ToArray());

            throw new InvalidOperationException(
                "Unexpected timeselections token");
        }

        public ITimeSelector Visit(ExpressionParser.TimeselectionContext context)
        {
            if (context.rangeselection() != null)
                return _rangeSelectionVisitor.Visit(context.rangeselection());

            if (context.ordinals() != null && context.daysofweek() != null)
                return new TimeSelector(
                    ordinals: _ordinalVisitor.Visit(context.ordinals()),
                    daySelectors: _dayOfWeekVisitor.Visit(context.daysofweek()));

            if (context.ordinals() != null)
                return new TimeSelector(
                    ordinals: _ordinalVisitor.Visit(context.ordinals()),
                    daySelectors: new[] { new All() });

            if (context.daythenth() != null && context.EVERY() != null)
                return new DayTheNthVisitor(new All()).Visit(context.daythenth());

            if (context.daythenth() != null && context.EVERY() == null)
                return new DayTheNthVisitor(new First()).Visit(context.daythenth());

            if (context.daysofweek() != null && context.EVERY() != null)
                return new TimeSelector(
                    ordinals: new All(),
                    daySelectors: _dayOfWeekVisitor.Visit(context.daysofweek()));

            if (context.daysofweek() != null && context.EVERY() == null)
                return new TimeSelector(
                    ordinals: new First(),
                    daySelectors: _dayOfWeekVisitor.Visit(context.daysofweek()));

            if (context.EVERY() != null && context.DAY() != null)
                return new All();

            throw new InvalidOperationException(
                "Unexpected timeselection token");
        }
    }
}