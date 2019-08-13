using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Periods;

namespace DateExpressions.Generated.DateGenerators
{
    internal class DateGenerator : IDateGenerator
    {
        private readonly YearlySelection[] _yearlySelections;

        public DateGenerator(
            YearlySelection[] yearlySelections)
        {
            _yearlySelections = yearlySelections;
        }

        public IEnumerable<Date> Generate(Date @from, Date to)
        {
            var period = new Period(from, to);

            return _yearlySelections
                .SelectMany(yearlySelection => yearlySelection.Generate(new[] {period}))
                .Where(date => date.IsWithin(from, to))
                .Distinct()
                .OrderBy(date => date);
        }
    }
}