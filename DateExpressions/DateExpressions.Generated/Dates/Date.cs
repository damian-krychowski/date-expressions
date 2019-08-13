using System;

namespace DateExpressions.Generated.Dates
{
    public class Date : IComparable<Date>, IEquatable<Date>
    {
        public Date(int year, int month, int day)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public int Day { get; }
        public int Month { get; }
        public int Year { get; }

        public int CompareTo(Date other)
        {
            if (Year < other.Year) return -1;

            if (Year == other.Year)
            {
                if (Month < other.Month) return -1;
                if (Month == other.Month) return Day.CompareTo(other.Day);
            }

            return 1;
        }

        public override string ToString()
        {
            return $"{Year}-{Month:00}-{Day:00}";
        }

        public bool Equals(Date other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Day == other.Day && Month == other.Month && Year == other.Year;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Date) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Day;
                hashCode = (hashCode * 397) ^ Month;
                hashCode = (hashCode * 397) ^ Year;
                return hashCode;
            }
        }
    }
}
