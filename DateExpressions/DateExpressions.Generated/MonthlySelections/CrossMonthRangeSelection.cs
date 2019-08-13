using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Periods;

namespace DateExpressions.Generated.MonthlySelections
{
    internal class CrossMonthRangeSelection : ISelection
    {
        private readonly PointInMonth _from;
        private readonly PointInMonth _to;
        
        public CrossMonthRangeSelection(PointInMonth from, PointInMonth to)
        {
            _from = @from;
            _to = to;
        }

        public IEnumerable<Date> Generate(IEnumerable<IPeriod> periods)
        {
            return periods
                .SelectMany(GenerateForSinglePeriod)
                .Distinct()
                .OrderBy(date => date);
        }

        private IEnumerable<Date> GenerateForSinglePeriod(IPeriod period)
        {
            var dates = _from
                .Pick(period.Months())
                .Match(
                    some: from => period.Days().Where(date => date.IsGreaterOrEqualTo(from)),
                    none: period.Days);

            return _to
                .Pick(period.Months())
                .Match(
                    some: to => dates.Where(date => date.IsLessOrEqualTo(to)),
                    none: () => dates);
        }
    }
}