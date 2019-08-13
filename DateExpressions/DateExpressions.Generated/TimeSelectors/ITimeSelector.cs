using System.Collections.Generic;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Periods;

namespace DateExpressions.Generated.TimeSelectors
{
    internal interface ITimeSelector
    {
        IEnumerable<Date> Filter(IPeriod period);
    }
}