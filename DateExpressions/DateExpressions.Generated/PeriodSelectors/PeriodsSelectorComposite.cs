using System.Collections.Generic;
using System.Linq;

namespace DateExpressions.Generated.PeriodSelectors
{
    internal class PeriodsSelectorComposite<TPeriod> : IPeriodsSelector<TPeriod>
    {
        private readonly IPeriodsSelector<TPeriod>[] _periodsSelectors;

        public PeriodsSelectorComposite(IPeriodsSelector<TPeriod>[] periodsSelectors)
        {
            _periodsSelectors = periodsSelectors;
        }

        public IEnumerable<TPeriod> Pick(IEnumerable<TPeriod> periods)
            => _periodsSelectors
                .SelectMany(selector => selector.Pick(periods))
                .Distinct();
    }
}