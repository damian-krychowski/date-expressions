using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Periods;

namespace DateExpressions.Generated.Ordinals
{
    internal class Last : IOrdinal
    {
        public Option<T> Pick<T>(IEnumerable<T> enumerable) 
            => enumerable.Reverse().TryGetFirst();
    }
}