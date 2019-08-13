using System;
using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;

namespace DateExpressions.Generated.Periods
{
    public class WeekPeriod : IPeriod, IEquatable<WeekPeriod>, IComparable<WeekPeriod>
    {
        public Date Monday { get; }
        
        public Date From => Monday;

        public Date To => Calendar.AddDays(Monday, 6);

        public WeekPeriod(Date monday)
        {
            Monday = monday;
        }

        public bool Equals(WeekPeriod other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Monday, other.Monday);
        }

        public int CompareTo(WeekPeriod other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Comparer<Date>.Default.Compare(Monday, other.Monday);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WeekPeriod) obj);
        }

        public override int GetHashCode()
        {
            return (Monday != null ? Monday.GetHashCode() : 0);
        }

        public override string ToString() => $"Monday {Monday}";
    }
}