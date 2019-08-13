using System.Collections.Generic;
using DateExpressions.Generated.Dates;

namespace DateExpressions.Generated.DaySelectors
{
    internal interface IDaySelector
    {
        IEnumerable<Date> PickDays(IEnumerable<Date> days);
    }
}