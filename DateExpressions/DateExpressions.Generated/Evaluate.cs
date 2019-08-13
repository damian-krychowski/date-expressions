using DateExpressions.Generated.DateGenerators;
using DateExpressions.Generated.ExpressionVisitors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated
{
    public class Evaluate : ExpressionBaseVisitor<object>
	{
        private readonly DayOfWeekVisitor _dayOfWeekVisitor;
        private readonly MonthVisitor _monthVisitor;
        private readonly NumeralVisitor _numeralVisitor;
        private readonly NumbersVisitor _numbersVisitor;
        private readonly DayTheNthVisitor _dayTheNthVisitor;
        private readonly OrdinalVisitor _ordinalVisitor;
        private readonly PointInTimeVisitor _pointInTimeVisitor;
        private readonly RangeSelectionVisitor _rangeSelectionVisitor;
        private readonly WeekSelectorsVisitor _weekSelectorsVisitor;
        private readonly TimeSelectionVisitor _timeSelectionVisitor;
        private readonly MonthRangeSelectionVisitor _monthRangeSelectionVisitor;
        private readonly SingleMonthSelectorVisitor _singleMonthSelectorVisitor;
        private readonly MonthsSelectorVisitor _monthsSelectorVisitor;
        private readonly YearRangeSelectionVisitor _yearRangeSelectionVisitor;
        private readonly YearSelectorVisitor _yearSelectorVisitor;
        private readonly WeeklySelectionVisitor _weeklySelectionVisitor;
        private readonly PointInMonthVisitor _pointInMonthVisitor;
        private readonly CrossMonthRangeSelectionVisitor _crossMonthRangeSelectionVisitor;
        private readonly MonthlySelectionVisitor _monthlySelectionVisitor;
        private readonly YearlySelectionVisitor _yearlySelectionVisitor;

        public Evaluate()
        {
            _dayOfWeekVisitor = new DayOfWeekVisitor();
            _monthVisitor = new MonthVisitor();
            _numeralVisitor = new NumeralVisitor();
            _numbersVisitor = new NumbersVisitor();

            _dayTheNthVisitor = new DayTheNthVisitor(
                _dayOfWeekVisitor, 
                _numeralVisitor);

            _ordinalVisitor = new OrdinalVisitor(
                _numeralVisitor);

            _pointInTimeVisitor = new PointInTimeVisitor(
                _ordinalVisitor, 
                _dayOfWeekVisitor);

            _rangeSelectionVisitor = new RangeSelectionVisitor(
                _pointInTimeVisitor);

            _weekSelectorsVisitor = new WeekSelectorsVisitor(
                _ordinalVisitor);

            _timeSelectionVisitor = new TimeSelectionVisitor(
                _rangeSelectionVisitor, 
                _ordinalVisitor, 
                _dayOfWeekVisitor,
                _dayTheNthVisitor);

            _monthRangeSelectionVisitor = new MonthRangeSelectionVisitor(
                _monthVisitor);

            _singleMonthSelectorVisitor = new SingleMonthSelectorVisitor(
                _monthVisitor,
                _ordinalVisitor);

            _monthsSelectorVisitor = new MonthsSelectorVisitor(
                _singleMonthSelectorVisitor,
                _ordinalVisitor,
                _monthRangeSelectionVisitor);

            _yearRangeSelectionVisitor = new YearRangeSelectionVisitor();

            _yearSelectorVisitor = new YearSelectorVisitor(
                _numbersVisitor,
                _ordinalVisitor,
                _yearRangeSelectionVisitor);

            _weeklySelectionVisitor = new WeeklySelectionVisitor(
                _weekSelectorsVisitor,
                _timeSelectionVisitor);

            _pointInMonthVisitor = new PointInMonthVisitor(
                _ordinalVisitor,
                _dayOfWeekVisitor,
                _singleMonthSelectorVisitor);

            _crossMonthRangeSelectionVisitor = new CrossMonthRangeSelectionVisitor(
                _pointInMonthVisitor);

            _monthlySelectionVisitor = new MonthlySelectionVisitor(
                _monthsSelectorVisitor, 
                _weeklySelectionVisitor,
                _crossMonthRangeSelectionVisitor);

            _yearlySelectionVisitor = new YearlySelectionVisitor(
                _yearSelectorVisitor,
                _monthlySelectionVisitor);
        }

        public override object VisitExp(ExpressionParser.ExpContext context)
        {
            return base.Visit(context.expression());
        }
        
        public override object VisitQueryx(ExpressionParser.QueryxContext context)
        {
            return new DateGenerator(
                yearlySelections: (YearlySelection[])VisitYearlyselections(context.yearlyselections()));
        }

        public override object VisitYearlyselections(ExpressionParser.YearlyselectionsContext context)
            => _yearlySelectionVisitor.Visit(context);

        public override object VisitYearlyselection(ExpressionParser.YearlyselectionContext context)
            => _yearlySelectionVisitor.Visit(context);

        public override object VisitMonthlyselections(ExpressionParser.MonthlyselectionsContext context)
            => _monthlySelectionVisitor.Visit(context);

        public override object VisitMonthlyselection(ExpressionParser.MonthlyselectionContext context)
            => _monthlySelectionVisitor.Visit(context);

        public override object VisitCrossmonthrangeselection(ExpressionParser.CrossmonthrangeselectionContext context)
            => _crossMonthRangeSelectionVisitor.Visit(context);

        public override object VisitPointinmonth(ExpressionParser.PointinmonthContext context)
            => _pointInMonthVisitor.Visit(context);

        public override object VisitWeeklyselections(ExpressionParser.WeeklyselectionsContext context)
            => _weeklySelectionVisitor.Visit(context);

        public override object VisitWeeklyselection(ExpressionParser.WeeklyselectionContext context)
            => _weeklySelectionVisitor.Visit(context);

        public override object VisitYearselectors(ExpressionParser.YearselectorsContext context)
            => _yearSelectorVisitor.Visit(context);

        public override object VisitYearselector(ExpressionParser.YearselectorContext context)
            => _yearSelectorVisitor.Visit(context);

        public override object VisitYearrangeselection(ExpressionParser.YearrangeselectionContext context)
            => _yearRangeSelectionVisitor.Visit(context);

        public override object VisitMonthsselectors(ExpressionParser.MonthsselectorsContext context)
            => _monthsSelectorVisitor.Visit(context);

        public override object VisitMonthsselector(ExpressionParser.MonthsselectorContext context)
            => _monthsSelectorVisitor.Visit(context);

        public override object VisitSinglemonthselector(ExpressionParser.SinglemonthselectorContext context)
            => _singleMonthSelectorVisitor.Visit(context);

        public override object VisitMonthrangeselection(ExpressionParser.MonthrangeselectionContext context)
            => _monthRangeSelectionVisitor.Visit(context);

        public override object VisitTimeselections(ExpressionParser.TimeselectionsContext context)
            => _timeSelectionVisitor.Visit(context);

        public override object VisitTimeselection(ExpressionParser.TimeselectionContext context)
            => _timeSelectionVisitor.Visit(context);

        public override object VisitOrdinals(ExpressionParser.OrdinalsContext context)
            => _ordinalVisitor.Visit(context);

        public override object VisitOrdinal(ExpressionParser.OrdinalContext context)
            => _ordinalVisitor.Visit(context);

        public override object VisitNumerals(ExpressionParser.NumeralsContext context)
            => _numeralVisitor.Visit(context);

        public override object VisitNumeral(ExpressionParser.NumeralContext context)
            => _numeralVisitor.Visit(context);

        public override object VisitNumbers(ExpressionParser.NumbersContext context)
            => _numbersVisitor.Visit(context);

        public override object VisitWeekselectors(ExpressionParser.WeekselectorsContext context)
            => _weekSelectorsVisitor.Visit(context);

        public override object VisitRangeselection(ExpressionParser.RangeselectionContext context)
            => _rangeSelectionVisitor.Visit(context);

        public override object VisitPointintime(ExpressionParser.PointintimeContext context)
            => _pointInTimeVisitor.Visit(context);

        public override object VisitDaythenth(ExpressionParser.DaythenthContext context)
            => _dayTheNthVisitor.Visit(context);

        public override object VisitMonth(ExpressionParser.MonthContext context)
            => _monthVisitor.Visit(context);

        public override object VisitDaysofweek(ExpressionParser.DaysofweekContext context)
            => _dayOfWeekVisitor.Visit(context);

        public override object VisitDayofweek(ExpressionParser.DayofweekContext context) 
            => _dayOfWeekVisitor.Visit(context);
    }
}