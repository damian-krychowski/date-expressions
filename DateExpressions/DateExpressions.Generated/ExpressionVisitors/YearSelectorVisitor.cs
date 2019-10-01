using System;
using System.Linq;
using DateExpressions.Generated.Periods;
using DateExpressions.Generated.PeriodSelectors;
using DateExpressions.Generated.TimeSelectors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class YearSelectorVisitor
    {
        private readonly NumbersVisitor _numbersVisitor = new NumbersVisitor();
        private readonly OrdinalVisitor _ordinalVisitor = new OrdinalVisitor();
        private readonly YearRangeSelectionVisitor _yearRangeSelectionVisitor = new YearRangeSelectionVisitor();
        

        public IPeriodsSelector<YearPeriod> Visit(ExpressionParser.YearselectorsContext context)
        {
            var yearGroups = context.yearselector();

            if (yearGroups != null && yearGroups.Any())
                return new PeriodsSelectorComposite<YearPeriod>(yearGroups
                    .Select(Visit)
                    .ToArray());

            throw new InvalidOperationException(
                "Unexpected yearselector token");
        }

        public IPeriodsSelector<YearPeriod> Visit(ExpressionParser.YearselectorContext context)
        {
            if (context.EVERY() != null)
                return new All<YearPeriod>();

            if (context.numbers() != null)
                return new SpecificPeriodsSelector<YearPeriod>(
                    periods: _numbersVisitor.Visit(context.numbers())
                        .Select(year => new YearPeriod(year))
                        .ToArray());

            if (context.ordinals() != null)
                return new OrdinalPeriodsSelector<YearPeriod>(
                    ordinal: _ordinalVisitor.Visit(context.ordinals()));

            if (context.yearrangeselection() != null)
                return _yearRangeSelectionVisitor.Visit(context.yearrangeselection());

            throw new InvalidOperationException(
                "Unexpected yearselector token");
        }
    }
}