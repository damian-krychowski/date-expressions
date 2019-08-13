using System.Collections.Generic;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.DaySelectors;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Ordinals;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;

namespace DateExpressions.Generated.MonthlySelections
{
    internal class PointInMonth
    {
        private readonly IOrdinal _ordinal;
        private readonly IDaySelector _daySelector;
        private readonly IPeriodSelector<MonthPeriod> _monthSelector;

        public PointInMonth(IOrdinal ordinal, IDaySelector daySelector, IPeriodSelector<MonthPeriod> monthSelector)
        {
            _ordinal = ordinal;
            _daySelector = daySelector;
            _monthSelector = monthSelector;
        }

        public Option<Date> Pick(IEnumerable<MonthPeriod> months)
        {
            var monthOption = _monthSelector.Pick(months);

            return monthOption.Select(month =>
            {
                var selectedDays = _daySelector.PickDays(month.Days());
                return _ordinal.Pick(selectedDays);
            });
        }
    }
}