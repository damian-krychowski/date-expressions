using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Periods;

namespace DateExpressions.Generated.TimeSelectors
{
    internal class RangeSelector : ITimeSelector
    {
        private readonly PointInTime _from;
        private readonly PointInTime _to;

        public RangeSelector(
            PointInTime @from,
            PointInTime to)
        {
            _from = @from;
            _to = to;
        }

        public IEnumerable<Date> Filter(IPeriod period)
        {
            var dates = _from
                .Pick(period.Days())
                .Match(
                    some: from => period.Days().Where(date => date.IsGreaterOrEqualTo(from)),
                    none: period.Days);

            return _to
                .Pick(period.Days())
                .Match(
                    some: to => dates.Where(date => date.IsLessOrEqualTo(to)),
                    none: () => dates);
        }
    }
}