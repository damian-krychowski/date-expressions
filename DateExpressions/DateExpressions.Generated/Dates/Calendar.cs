using System;
using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Periods;

namespace DateExpressions.Generated.Dates
{
    internal static class Calendar
    {
        internal static int DaysInMonth(int year, int month)
            => DateTime.DaysInMonth(year, month);

        internal static Date GetFirstMondayBefore(Date date)
        {
            var datetime = ToDateTime(date);

            return ToDate(datetime.AddDays(DistanceToMonday(datetime) * -1));
        }

        private static int DistanceToMonday(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case System.DayOfWeek.Monday: return 0;
                case System.DayOfWeek.Tuesday: return 1;
                case System.DayOfWeek.Wednesday: return 2;
                case System.DayOfWeek.Thursday: return 3;
                case System.DayOfWeek.Friday: return 4;
                case System.DayOfWeek.Saturday: return 5;
                case System.DayOfWeek.Sunday: return 6;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        internal static Date AddDays(Date date, int count) 
            => ToDate(ToDateTime(date).AddDays(count));

        internal static DayOfWeek DayOfWeek(Date date)
            => ToDateTime(date).DayOfWeek;

        internal static IEnumerable<Date> Days(Date from, Date to)
        {
            if (from.IsGreaterThan(to))
                throw new ArgumentOutOfRangeException(nameof(from),
                    $"{nameof(from)} ({from}) cannot be greater than {nameof(to)} ({to})");

            var buffer = from;
            do
            {
                yield return buffer;

                buffer = AddDays(buffer, 1);
            } while (buffer.IsLessOrEqualTo(to));
        }

        private static DateTime ToDateTime(Date date)
            => new DateTime(date.Year, date.Month, date.Day);

        private static Date ToDate(DateTime dateTime)
            => new Date(dateTime.Year, dateTime.Month, dateTime.Day);
    }
}