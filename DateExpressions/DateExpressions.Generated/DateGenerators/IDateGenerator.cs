using System;
using System.Collections.Generic;
using DateExpressions.Generated.Dates;

namespace DateExpressions.Generated.DateGenerators
{
    public interface IDateGenerator
    {
        IEnumerable<Date> Generate(Date from, Date to);
    }
}