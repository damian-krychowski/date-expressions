using System.Collections.Generic;
using System.Linq;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Periods;

namespace DateExpressions.Generated.TimeSelectors
{
    internal class TimeSelectorComposite : ITimeSelector
    {
        private readonly ITimeSelector[] _timeSelectors;

        public TimeSelectorComposite(ITimeSelector[] timeSelectors)
        {
            _timeSelectors = timeSelectors;
        }

        public IEnumerable<Date> Filter(IPeriod period)
        {
            return _timeSelectors
                .SelectMany(timeSelector => timeSelector.Filter(period))
                .Distinct();
        }
    }
}