using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.DaySelectors;
using DateExpressions.Generated.Ordinals;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;
using DateExpressions.Generated.TimeSelectors;

namespace DateExpressions.Generated
{
    internal class All : IOrdinals, IDaySelector, ITimeSelector
    {
        public IEnumerable<T> Pick<T>(IEnumerable<T> enumerable) => enumerable;

        public IEnumerable<Date> PickDays(IEnumerable<Date> days) => days;

        public IEnumerable<Date> Filter(IPeriod period) => period.Days();
    }

    internal class All<T> : IPeriodsSelector<T>
    {
        public IEnumerable<T> Pick(IEnumerable<T> periods) => periods;
    }

    internal class First : IOrdinals
    {
        public IEnumerable<T> Pick<T>(IEnumerable<T> enumerable) => enumerable.Take(1);
    }
}