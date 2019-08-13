using System;
using DateExpressions.Generated.Dates;

namespace DateExpressions.Test
{
    public static class DateTimeExtensions
    {
        public static Date ToDate(this DateTime dateTime) => 
            new Date(dateTime.Year, dateTime.Month, dateTime.Day);
    }
}