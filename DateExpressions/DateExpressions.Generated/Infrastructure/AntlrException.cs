using System;
using System.Collections.Generic;

namespace DateExpressions.Generated.Infrastructure
{
	public class AntlrException : AggregateException
	{
		public AntlrException(string message, IEnumerable<Exception> innerExceptions) : base(message, innerExceptions)
		{
		}
	}
}
