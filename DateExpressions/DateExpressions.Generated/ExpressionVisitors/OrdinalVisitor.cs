using System;
using System.Linq;
using DateExpressions.Generated.Ordinals;
using DateExpressions.Grammar;

namespace DateExpressions.Generated.ExpressionVisitors
{
    internal class OrdinalVisitor
    {
        private readonly NumeralVisitor _numeralVisitor;

        public OrdinalVisitor(NumeralVisitor numeralVisitor)
        {
            _numeralVisitor = numeralVisitor;
        }

        public IOrdinals Visit(ExpressionParser.OrdinalsContext context)
        {
            var ordinals = context.ordinal();

            if (ordinals != null && ordinals.Any())
                return new OrdinalComposite(ordinals
                    .Select(Visit)
                    .ToArray());

            throw new InvalidOperationException(
                "Unexpected ordinals token");
        }

        public IOrdinal Visit(ExpressionParser.OrdinalContext context)
        {
            if (context.FIRST() != null) return Nth.First;
            if (context.LAST() != null) return new Last();
            if (context.numeral() != null) return new Nth(_numeralVisitor.Visit(context.numeral()));

            throw new InvalidOperationException(
                "Unexpected ordinal token");
        }
    }
}