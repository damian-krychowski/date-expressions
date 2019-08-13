using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.DaySelectors;
using DateExpressions.Generated.Ordinals;
using DateExpressions.Generated.Periods;

namespace DateExpressions.Generated.TimeSelectors
{
    internal class TimeSelector : ITimeSelector
    {
        private readonly IOrdinals _ordinals;
        private readonly IDaySelector[] _daySelectors;

        public TimeSelector(
            IOrdinals ordinals,
            IDaySelector[] daySelectors)
        {
            _ordinals = ordinals;
            _daySelectors = daySelectors;
        }

        public IEnumerable<Date> Filter(IPeriod period)
        {
            return _daySelectors
                .Select(daySelector => daySelector.PickDays(period.Days()))
                .SelectMany(daySequence => _ordinals.Pick(daySequence));
        }
    }
}