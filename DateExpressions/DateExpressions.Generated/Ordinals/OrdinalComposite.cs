using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Infrastructure;

namespace DateExpressions.Generated.Ordinals
{
    internal class OrdinalComposite : IOrdinals
    {
        private readonly IOrdinal[] _ordinals;

        public OrdinalComposite(IOrdinal[] ordinals)
        {
            _ordinals = ordinals;
        }

        public IEnumerable<T> Pick<T>(IEnumerable<T> enumerable)
        {
            return _ordinals
                .Select(ordinal => ordinal.Pick(enumerable))
                .Items()
                .Distinct();
        }
    }
}