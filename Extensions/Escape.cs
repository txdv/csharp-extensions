using System;
using System.Text;

namespace Extensions
{
	public static class EscapeExtensions
	{
		public static Func<char, string> DefaultConverter = ch => string.Format(@"\x{0:x}", (int)ch);
		
		public static string Escape(this string text)
		{
			return text.Escape(DefaultConverter);
		}
		
		public static string Escape(this string text, Func<char, string> converter)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("\"");
			foreach (char c in text) {
				sb.Append(c.Escape(converter));
			}
			sb.Append("\"");
			return sb.ToString();
		}
		
		public static string Escape(this char c)
		{
			return c.Escape(DefaultConverter);
		}
		
		public static string Escape(this char c, Func<char, string> converter)
		{
			switch (c) {
			case ' ':
				return @" ";
			case '"':
				return "\\\"";
			}
			
			if (c > 32) {
				return new string(new char[] { c });
			}
			
			switch (c) {
			case '\a':
				return @"\a";
			case '\b':
				return @"\b";
			case '\n':
				return @"\n";
			case '\v':
				return @"\v";
			case '\r':
				return @"\r";
			case '\f':
				return @"\f";
			case '\t':
				return @"\t";
			default:
				return converter(c);
			}
		}
	}
}

