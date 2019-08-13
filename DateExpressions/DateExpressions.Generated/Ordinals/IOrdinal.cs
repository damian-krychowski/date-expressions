using System.Collections.Generic;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Periods;

namespace DateExpressions.Generated.Ordinals
{
    internal interface IOrdinals
    {
        IEnumerable<T> Pick<T>(IEnumerable<T> enumerable);
    }

    internal interface IOrdinal
    {
        Option<T> Pick<T>(IEnumerable<T> enumerable);
    }
}