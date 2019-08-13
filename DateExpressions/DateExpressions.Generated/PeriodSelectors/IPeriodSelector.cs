using System.Collections.Generic;
using DateExpressions.Generated.Infrastructure;

namespace DateExpressions.Generated.PeriodSelectors
{
    internal interface IPeriodSelector<TPeriod>
    {
        Option<TPeriod> Pick(IEnumerable<TPeriod> periods);
    }
}