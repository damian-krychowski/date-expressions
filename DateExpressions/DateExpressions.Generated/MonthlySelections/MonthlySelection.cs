using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.DateGenerators;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;

namespace DateExpressions.Generated.MonthlySelections
{
    internal class MonthlySelection: ISelection
    {
        private readonly Option<IPeriodsSelector<MonthPeriod>> _monthsSelector;
        private readonly WeeklySelection[] _weeklySelections;

        public MonthlySelection(
            Option<IPeriodsSelector<MonthPeriod>> monthsSelector,
            WeeklySelection[] weeklySelections)
        {
            _monthsSelector = monthsSelector;
            _weeklySelections = weeklySelections;
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
            var selectedPeriods = _monthsSelector.Match(
                some: monthSelector => monthSelector.Pick(period.Months()),
                none: () => (IEnumerable<IPeriod>) new[] {period});

            return _weeklySelections
                .SelectMany(weeklySelection => weeklySelection.Generate(selectedPeriods));
        }
    }
}