using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.MonthlySelections;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;

namespace DateExpressions.Generated.DateGenerators
{
    internal class YearlySelection
    {
        private readonly Option<IPeriodsSelector<YearPeriod>> _yearsSelector;
        private readonly ISelection[] _monthlySelections;

        public YearlySelection(
            Option<IPeriodsSelector<YearPeriod>> yearsSelector,
            ISelection[] monthlySelections)
        {
            _yearsSelector = yearsSelector;
            _monthlySelections = monthlySelections;
        }

        public IEnumerable<Date> Generate(IEnumerable<IPeriod> periods)
        {
            return periods
                .SelectMany(GenerateForSinglePeriod)
                .Distinct()
                .OrderBy(date => date);
        }

        public IEnumerable<Date> GenerateForSinglePeriod(IPeriod period)
        {
            var selectedPeriods = _yearsSelector.Match(
                some: yearSelector => yearSelector.Pick(period.Years()),
                none: () => (IEnumerable<IPeriod>) new[] {period});

            return _monthlySelections
                .SelectMany(monthlySelection => monthlySelection.Generate(selectedPeriods));
        }
    }
}