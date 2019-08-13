using System.Collections.Generic;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.DaySelectors;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Ordinals;

namespace DateExpressions.Generated.TimeSelectors
{
    internal class PointInTime
    {
        private readonly IOrdinal _ordinal;
        private readonly IDaySelector _daySelector;

        public PointInTime(IOrdinal ordinal, IDaySelector daySelector)
        {
            _ordinal = ordinal;
            _daySelector = daySelector;
        }

        public Option<Date> Pick(IEnumerable<Date> dates)
        {
            var selectedDays = _daySelector
                .PickDays(dates);

            return _ordinal.Pick(selectedDays);
        }
    }
}