using System.Linq;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class NumbersVisitor
    {
        public int[] Visit(ExpressionParser.NumbersContext context)
        {
            return context
                .NUMBER()
                .Select(num => int.Parse(num.GetText()))
                .ToArray();
        }
    }
}