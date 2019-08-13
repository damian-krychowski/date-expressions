using System;

namespace DateExpressions.Generated.Infrastructure
{
    public static class ComparableExtensions
    {
        public static bool IsWithin<T>(this T value, T from, T to) where T : IComparable<T>
        {
            return value.IsGreaterOrEqualTo(from) && 
                   value.IsLessOrEqualTo(to);
        }

        public static bool IsLessThan<T>(this T value, T other) where T : IComparable<T>
        {
            return value.CompareTo(other) < 0;
        }

        public static bool IsLessOrEqualTo<T>(this T value, T other) where T : IComparable<T>
        {
            return value.CompareTo(other) <= 0;
        }

        public static bool IsGreaterThan<T>(this T value, T other) where T : IComparable<T>
        {
            return value.CompareTo(other) > 0;
        }

        public static bool IsGreaterOrEqualTo<T>(this T value, T other) where T : IComparable<T>
        {
            return value.CompareTo(other) >= 0;
        }
    }
}