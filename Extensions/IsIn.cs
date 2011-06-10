using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
	public static class ArrayExtensions
	{
		public static bool IsIn<T>(this T element, IEnumerable<T> ienumerable)
		{
			return ienumerable.Contains(element);
		}
	}
}

