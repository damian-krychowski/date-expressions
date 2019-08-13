using System;
using System.Collections.Generic;
using System.Linq;

namespace DateExpressions.Generated.Infrastructure.RecognitionErrorsSearch
{
	public static class Tree
	{
		public static IEnumerable<T> Traverse<T>(T item, Func<T, IEnumerable<T>> childSelector)
		{
			var stack = new Stack<T>();
			stack.Push(item);
			while (stack.Any())
			{
				var next = stack.Pop();
				yield return next;

				var children = childSelector(next);

				if (children != null)
				{
					foreach (var child in children)
					{
						stack.Push(child);
					}
				}
			}
		}
	}
}