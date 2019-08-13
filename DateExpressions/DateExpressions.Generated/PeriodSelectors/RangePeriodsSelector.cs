using System;
using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Infrastructure;

namespace DateExpressions.Generated.PeriodSelectors
{
    internal class RangePeriodsSelector<TPeriod, TIndex> :
        IPeriodsSelector<TPeriod>
        where TIndex: IComparable<TIndex>
    {
        private readonly TIndex _from;
        private readonly TIndex _to;
        private readonly Func<TPeriod, TIndex> _getIndexOfPeriod;

        public RangePeriodsSelector(Func<TPeriod, TIndex> getIndexOfPeriod, TIndex from, TIndex to)
        {
            _from = @from;
            _to = to;
            _getIndexOfPeriod = getIndexOfPeriod;
        }
        
        public IEnumerable<TPeriod> Pick(IEnumerable<TPeriod> periods)
            => periods.Where(period => _getIndexOfPeriod(period).IsWithin(_from, _to));
    }
}