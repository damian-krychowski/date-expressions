using DateExpressions.Generated.DateGenerators;
using DateExpressions.Generated.ExpressionVisitors;
using DateExpressions.Grammar;

namespace DateExpressions.Generated
{
    public class Evaluate : ExpressionBaseVisitor<object>
	{
        private readonly YearlySelectionVisitor _yearlySelectionVisitor = new YearlySelectionVisitor();

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
    }
}