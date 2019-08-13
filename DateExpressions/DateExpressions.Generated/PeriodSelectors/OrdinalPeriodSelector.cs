using System.Collections.Generic;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Ordinals;

namespace DateExpressions.Generated.PeriodSelectors
{
    internal class OrdinalPeriodSelector<TPeriod> : IPeriodSelector<TPeriod>
    {
        private readonly IOrdinal _ordinal;

        public OrdinalPeriodSelector(IOrdinal ordinal)
        {
            _ordinal = ordinal;
        }

        public Option<TPeriod> Pick(IEnumerable<TPeriod> periods)
            => _ordinal.Pick(periods);
    }
}