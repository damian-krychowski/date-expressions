using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;
using DateExpressions.Generated.TimeSelectors;

namespace DateExpressions.Generated.DateGenerators
{
    internal class WeeklySelection
    {
        private readonly Option<IPeriodsSelector<WeekPeriod>> _weeksSelector;
        private readonly ITimeSelector _timeSelector;

        public WeeklySelection(
            Option<IPeriodsSelector<WeekPeriod>> weeksSelector,
            ITimeSelector timeSelector)
        {
            _weeksSelector = weeksSelector;
            _timeSelector = timeSelector;
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
            return _weeksSelector
                .Match(
                    some: weeksSelector => weeksSelector.Pick(period.Weeks()),
                    none: () => (IEnumerable<IPeriod>) new[] {period})
                .SelectMany(p => _timeSelector.Filter(p));
        }
    }
}