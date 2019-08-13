using System.Collections.Generic;
using DateExpressions.Generated.Ordinals;

namespace DateExpressions.Generated.PeriodSelectors
{
    internal class OrdinalPeriodsSelector<TPeriod> : IPeriodsSelector<TPeriod>
    {
        private readonly IOrdinals _ordinal;

        public OrdinalPeriodsSelector(IOrdinals ordinal)
        {
            _ordinal = ordinal;
        }

        public IEnumerable<TPeriod> Pick(IEnumerable<TPeriod> periods)
            => _ordinal.Pick(periods);
    }
}