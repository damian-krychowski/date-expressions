using System.Linq;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class NumeralVisitor
    {
        public int[] Visit(ExpressionParser.NumeralsContext context)
        {
            return context
                .numeral()
                .Select(Visit)
                .ToArray();
        }

        public int Visit(ExpressionParser.NumeralContext context)
        {
            return int.Parse(context.NUMBER().GetText());
        }
    }
}