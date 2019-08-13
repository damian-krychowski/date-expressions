using System;
using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Ordinals;

namespace DateExpressions.Generated.PeriodSelectors
{
    internal class SpecificPeriodsSelector<TPeriod> :
        IPeriodsSelector<TPeriod> where TPeriod : IEquatable<TPeriod>
    {
        private readonly TPeriod[] _periods;

        public SpecificPeriodsSelector(TPeriod[] periods)
        {
            _periods = periods;
        }

        public IEnumerable<TPeriod> Pick(IEnumerable<TPeriod> periods)
            => periods.Where(period => _periods.Contains(period));
    }
}