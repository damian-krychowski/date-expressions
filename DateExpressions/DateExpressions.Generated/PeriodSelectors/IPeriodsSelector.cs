using System.Collections.Generic;

namespace DateExpressions.Generated.PeriodSelectors
{
    internal interface IPeriodsSelector<TPeriod>
    {
        IEnumerable<TPeriod> Pick(IEnumerable<TPeriod> periods);
    }
}
