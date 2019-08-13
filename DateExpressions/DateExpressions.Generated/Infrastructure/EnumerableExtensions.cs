using System;
using System.Collections.Generic;
using System.Linq;

namespace DateExpressions.Generated.Infrastructure
{
    public static class EnumerableExtensions
    {
        public static Option<T> TryGetFirst<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.TryGetFirst(x => true);
        }

        public static Option<T> TryGetFirst<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            var firstOrDefault = enumerable.FirstOrDefault(predicate);

            return firstOrDefault != null
                ? Option<T>.Some(firstOrDefault) 
                : Option<T>.None;
        }

        public static IEnumerable<T> PickElements<T>(this IEnumerable<T> enumerable, IEnumerable<int> indexes)
        {
            using (var collectionEnu = enumerable.GetEnumerator())
            using (var indexesEnu = indexes.GetEnumerator())
            {
                var previousNumber = -1;
                while (indexesEnu.MoveNext())
                {
                    for (int i = 0; i < indexesEnu.Current - previousNumber; i++)
                    {
                        if (!collectionEnu.MoveNext())
                        {
                            yield break;
                        }
                    }

                    yield return collectionEnu.Current;
                    previousNumber = indexesEnu.Current;
                }
            }
        }

        public static IEnumerable<T> Items<T>(this IEnumerable<Option<T>> enumerable)
        {
            foreach (var option in enumerable)
            {
                if (option.TryGet(out var item))
                    yield return item;
            }
        }
    }
}