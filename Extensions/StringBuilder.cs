using System;
using System.Text;

namespace Extensions
{
	public static class StringBuilderExtensions
	{
		public static StringBuilder Append(this StringBuilder stringBuilder, string format, params object[] args)
		{
			return stringBuilder.Append(string.Format(format, args));
		}
	}
}

