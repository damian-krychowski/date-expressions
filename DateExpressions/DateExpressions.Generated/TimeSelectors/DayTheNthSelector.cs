using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.DaySelectors;
using DateExpressions.Generated.Ordinals;
using DateExpressions.Generated.Periods;

namespace DateExpressions.Generated.TimeSelectors
{
    internal class DayTheNthSelector : ITimeSelector
    {
        private readonly WeekDay _weekDay;
        private readonly int _nth;

        public DayTheNthSelector(
            WeekDay weekDay,
            int nth)
        {
            _weekDay = weekDay;
            _nth = nth;
        }

        public IEnumerable<Date> Filter(IPeriod period)
            => _weekDay
                .PickDays(period.Days())
                .Where(day => day.Day == _nth);
    }
}