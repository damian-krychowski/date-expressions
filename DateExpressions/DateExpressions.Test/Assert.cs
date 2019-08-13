using System;
using System.Globalization;
using System.Linq;
using DateExpressions.Generated.Dates;
using FluentAssertions;

namespace DateExpressions.Test
{
    public class Assert
    {
        const string DateFormat = "yyyy-MM-dd";

        private string[] _expressions;
        private Date _from;
        private Date _to;

        public static Assert Expression(string expression)
        {
            return new Assert()
            {
                _expressions =  new []{expression}
            };
        }

        public static Assert Expressions(params string[] expressions)
        {
            return new Assert()
            {
                _expressions = expressions
            };
        }

        public Assert From(string fromDate)
        {
            _from = ParseDate(fromDate);
            return this;
        }

        public Assert To(string toDate)
        {
            _to = ParseDate(toDate);
            return this;
        }

        public void ShouldGive(params string[] expectedDates)
        {
            var expectedResults = expectedDates
                .Select(ParseDate)
                .ToArray();

            foreach (var expression in _expressions)
            {
                DateExpression
                    .Evaluate(expression)
                    .Generate(_from, _to)
                    .Should()
                    .BeEquivalentTo(expectedResults, because: expression);
            }
        }

        private static Date ParseDate(string dateStr)
        {
            return DateTime
                .ParseExact(dateStr, DateFormat, CultureInfo.InvariantCulture)
                .ToDate();
        }
    }
}