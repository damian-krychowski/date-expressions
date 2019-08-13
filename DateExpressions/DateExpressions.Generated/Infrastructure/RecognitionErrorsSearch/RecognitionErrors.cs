using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace DateExpressions.Generated.Infrastructure.RecognitionErrorsSearch
{
	public static class RecognitionErrors
	{
		public static RecognitionException[] FindAll(IParseTree context)
		{
			return Tree
				.Traverse(context, ctx => ctx.GetChildren())
				.OfType<ParserRuleContext>()
				.Where(x => x.exception != null)
				.Select(x => x.exception)
				.ToArray();
		}
	}
}
