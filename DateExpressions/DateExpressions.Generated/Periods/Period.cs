using System;
using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Infrastructure;

namespace DateExpressions.Generated.Periods
{
    public class Period : IPeriod
    {
        public Date From { get; }
        public Date To { get; }

        public Period(Date from, Date to)
        {
            if(from.IsGreaterThan(to))
                throw new ArgumentOutOfRangeException(nameof(from));
            
            From = @from;
            To = to;
        }
    }
}