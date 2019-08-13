using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
using DateExpressions.Generated;
using DateExpressions.Generated.DateGenerators;
using DateExpressions.Generated.Dates;
using DateExpressions.Generated.Infrastructure;
using DateExpressions.Generated.Infrastructure.RecognitionErrorsSearch;
using DateExpressions.Grammar;

namespace DateExpressions
{
    public class DateExpression
    {
        public static IDateGenerator Evaluate(string expression)
        {
            using (var stream = new MemoryStream(Encoding.ASCII.GetBytes(expression)))
            using (var streamReader = new StreamReader(stream))
            {
                return Evaluate(streamReader);
            }
        }

        public static IDateGenerator Evaluate(StreamReader expression)
        {
            var lexer = new ExpressionLexer(new AntlrInputStream(expression));
            var parser = new ExpressionParser(new CommonTokenStream(lexer));

            while (!parser.MatchedEndOfFile)
            {
                var tree = parser.exp();

                ThrowIfAnyRecognitionExceptionFound(tree);

                var output = new Evaluate().Visit(tree);

                return (IDateGenerator) output;
            }

            return new NullDateGenerator();
        }

        private static void ThrowIfAnyRecognitionExceptionFound(ExpressionParser.ExpContext tree)
        {
            var recognitionExceptions = RecognitionErrors
                .FindAll(tree);

            if (recognitionExceptions.Any())
            {
                throw new AntlrException(
                    $"Following problems were found while parsing the expression: {tree}", recognitionExceptions);
            }
        }
        
        private class NullDateGenerator : IDateGenerator
        {
            public IEnumerable<Date> Generate(Date @from, Date to)
            {
                return Enumerable.Empty<Date>();
            }
        }
    }
}