using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Infrastructure;

namespace DateExpressions.Generated.Ordinals
{
    internal class Nth : IOrdinal
    {
        private readonly int  _position;

        public Nth(int position)
        {
            _position =  position ;
        }

        public static Nth First => new Nth(1);

        public Option<T> Pick<T>(IEnumerable<T> enumerable)
            => enumerable.Skip(_position - 1).TryGetFirst();
    }
}