using System;
using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;

namespace DateExpressions.Generated.Periods
{
    internal class YearPeriod : 
        IPeriod, 
        IEquatable<YearPeriod>, 
        IComparable<YearPeriod>
    {
        public int Year { get; }

        public Date From => new Date(Year, 1, 1);
        public Date To => new Date(Year, 12, 31);

        public YearPeriod(int year)
        {
            Year = year;
        }

        public bool Equals(YearPeriod other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Year == other.Year;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YearPeriod) obj);
        }

        public override int GetHashCode()
        {
            return Year;
        }

        public int CompareTo(YearPeriod other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Year.CompareTo(other.Year);
        }

        public override string ToString() => Year.ToString();
    }
}