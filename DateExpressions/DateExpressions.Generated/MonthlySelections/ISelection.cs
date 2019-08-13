using System.Collections.Generic;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Periods;

namespace DateExpressions.Generated.MonthlySelections
{
    internal interface ISelection
    {
        IEnumerable<Date> Generate(IEnumerable<IPeriod> periods);
    }
}