using System.Collections.Generic;

namespace DateExpressions.Generated.PeriodSelectors
{
    internal class SingleToManyAdapter<TPeriod> : IPeriodsSelector<TPeriod>
    {
        private readonly IPeriodSelector<TPeriod> _periodSelector;

        public SingleToManyAdapter(IPeriodSelector<TPeriod> periodSelector)
        {
            _periodSelector = periodSelector;
        }

        public IEnumerable<TPeriod> Pick(IEnumerable<TPeriod> periods)
        {
            if (_periodSelector.Pick(periods).TryGet(out var item))
                yield return item;
        }
    }
}