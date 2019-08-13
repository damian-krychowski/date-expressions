using System.Collections;
using DateExpressions.Generated.Dates;

namespace DateExpressions.Generated.Periods
{
    internal interface IPeriod
    {
        Date From { get; }
        Date To { get; }
    }
}