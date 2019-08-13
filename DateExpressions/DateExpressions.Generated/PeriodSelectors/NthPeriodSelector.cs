using System;
using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Infrastructure;

namespace DateExpressions.Generated.PeriodSelectors
{
    internal class NthPeriodSelector<TPeriod, TIndex> :
        IPeriodSelector<TPeriod>
        where TIndex : IEquatable<TIndex>
    {
        private readonly Func<TPeriod, TIndex> _getIndexOfPeriod;
        private readonly TIndex _index;

        public NthPeriodSelector(Func<TPeriod, TIndex> getIndexOfPeriod, TIndex index)
        {
            _getIndexOfPeriod = getIndexOfPeriod;
            _index = index;
        }

        public Option<TPeriod> Pick(IEnumerable<TPeriod> periods)
            => periods.TryGetFirst(period => _getIndexOfPeriod(period).Equals(_index));
    }
}