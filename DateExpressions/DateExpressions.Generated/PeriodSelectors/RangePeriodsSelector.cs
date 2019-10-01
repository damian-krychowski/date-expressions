using System;
using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Infrastructure;

namespace DateExpressions.Generated.PeriodSelectors
{
    internal class RangePeriodsSelector<TPeriod> :
        IPeriodsSelector<TPeriod>
    {
        private readonly int _from;
        private readonly int _to;
        private readonly Func<TPeriod, int> _getIndexOfPeriod;

        public RangePeriodsSelector(Func<TPeriod, int> getIndexOfPeriod, int from, int to)
        {
            _from = @from;
            _to = to;
            _getIndexOfPeriod = getIndexOfPeriod;
        }
        
        public IEnumerable<TPeriod> Pick(IEnumerable<TPeriod> periods)
            => Enumerable.Range(_from, _to - _from + 1)
                .SelectMany(index => periods
                    .TryGetFirst(period => _getIndexOfPeriod(period) == index)
                    .ToEnumerable());
    }
}