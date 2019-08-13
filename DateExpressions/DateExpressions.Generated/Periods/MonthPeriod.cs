using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using DateExpressions.Generated.Dates;

namespace DateExpressions.Generated.Periods
{
    public class MonthPeriod : 
        IPeriod, 
        IEquatable<MonthPeriod>, 
        IComparable<MonthPeriod>
    {
        public int Year { get; }
        public int Month { get; }
        
        public Date From => new Date(Year, Month, 1);
        public Date To => new Date(Year, Month, Calendar.DaysInMonth(Year, Month));

        public MonthPeriod(int year, int month)
        {
            Year = year;
            Month = month;
        }

        public MonthPeriod Next() => Month == 12
            ? new MonthPeriod(Year + 1, 1)
            : new MonthPeriod(Year, Month + 1); 

        public bool Equals(MonthPeriod other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Year == other.Year && Month == other.Month;
        }

        public int CompareTo(MonthPeriod other)
        {
            if (Year < other.Year) return -1;

            return Year == other.Year
                ? Month.CompareTo(other.Month)
                : 1;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((MonthPeriod) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Year * 397) ^ Month;
            }
        }

        public override string ToString() => $"{Year}-{Month}";
    }
}