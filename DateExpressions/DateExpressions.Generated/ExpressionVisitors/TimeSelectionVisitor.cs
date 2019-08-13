using System;
using System.Linq;
using DateExpressions.Generated.TimeSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class TimeSelectionVisitor
    {
        private readonly RangeSelectionVisitor _rangeSelectionVisitor;
        private readonly OrdinalVisitor _ordinalVisitor;
        private readonly DayOfWeekVisitor _dayOfWeekVisitor;
        private readonly DayTheNthVisitor _dayTheNthVisitor;

        public TimeSelectionVisitor(
            RangeSelectionVisitor rangeSelectionVisitor,
            OrdinalVisitor ordinalVisitor,
            DayOfWeekVisitor dayOfWeekVisitor,
            DayTheNthVisitor dayTheNthVisitor)
        {
            _rangeSelectionVisitor = rangeSelectionVisitor;
            _ordinalVisitor = ordinalVisitor;
            _dayOfWeekVisitor = dayOfWeekVisitor;
            _dayTheNthVisitor = dayTheNthVisitor;
        }

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

            if (context.daythenth() != null)
                return _dayTheNthVisitor.Visit(context.daythenth());

            if (context.daysofweek() != null)
                return new TimeSelector(
                    ordinals: new All(),
                    daySelectors: _dayOfWeekVisitor.Visit(context.daysofweek()));

            if (context.EVERY() != null && context.DAY() != null)
                return new All();

            throw new InvalidOperationException(
                "Unexpected timeselection token");
        }
    }
}