using System;
using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;

namespace DateExpressions.Generated.DaySelectors
{
    internal class WeekDay : IDaySelector
    {
        private readonly DayOfWeek _dayOfWeek;

        public WeekDay(DayOfWeek dayOfWeek)
        {
            _dayOfWeek = dayOfWeek;
        }

        public IEnumerable<Date> PickDays(IEnumerable<Date> days)
            => days.Where(day => Calendar.DayOfWeek(day) == _dayOfWeek);
    }
}