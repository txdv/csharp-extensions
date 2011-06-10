using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
	public static class RubyMethods
	{
		#region Join
		
		public static string Join(this object[] objectArray)
		{
			return objectArray.Join("");
		}
		
        public static string Join(this object[] objectArray, char c)
        {
            return objectArray.Join(new string(new char[] { c }));
        }
    
        public static string Join(this object[] objectArray, string delimeter)
        {
            return objectArray.Join(0, delimeter);
        }
		
		public static string Join(this object[] objectArray, int startIndex)
		{
			return objectArray.Join(startIndex, "");
		}
    
        public static string Join(this object[] objectArray, int startIndex, char c)
        {
            return objectArray.Join(startIndex, new string(new char[] { c }));
        }
		
		public static string Join(this object[] objectArray, int startIndex, int endIndex)
		{
			return objectArray.Join(startIndex, endIndex, "");
		}
		
		public static string Join(this object[] objectArray, int startIndex, int endIndex, char c)
		{
            return objectArray.Join(startIndex, endIndex, new string(new char[] { c }));
		}
    
        public static string Join(this object[] objectArray, int startIndex, string delimeter)
        {
			return objectArray.Join(startIndex, objectArray.Length, delimeter);
        }
		
		public static string Join(this object[] objectArray, int startIndex, int endIndex, string delimeter)
		{
			int length = objectArray.Length;
			
            if ((length == 0) || (objectArray.Length < startIndex)) {
                return string.Empty;
			}
			
			if (endIndex > length) {
				endIndex = length;
			}
    
            StringBuilder sb = new StringBuilder();
    
            for (int i = startIndex; i < endIndex; i++) {
				if (i > startIndex) {
                	sb.Append(delimeter);
				}
                sb.Append(objectArray[i]);
            }
    
            return sb.ToString();
		}
		
		#endregion
		
		#region Split
		
		public static string[] Split(this string text, char seperator)
		{
			return text.Split(new char[] { seperator });
		}
		
		public static string[] Split(this string text, char seperator, StringSplitOptions options)
		{
			return text.Split(new char[] { seperator }, options);
		}
		
		public static string[] Split(this string text, string seperator)
		{
			return text.Split(seperator, StringSplitOptions.None);
		}
		
		public static string[] Split(this string text, string seperator, StringSplitOptions options)
		{
			return text.Split(new string[] { seperator }, options);
		}
		
		#endregion
		
		#region Shift
		
		public static T[] Shift<T>(this T[] array)
		{
			if (array.LongLength <= 1) {
				return new T[] { };
			}
			
			T[] newArray = new T[array.LongLength - 1];
			
			for (long i = 1; i < array.LongLength; i++) {
				newArray[i - 1] = array[i];
			}
			
			return newArray;
		}
		
		public static string Shift(this string text)
		{
			return text.Shift(' ');
		}
		
		public static string Shift(this string text, char seperator)
		{
			return text.Split(seperator).Shift().Join(seperator);
		}
		
		public static string Shift(this string text, string seperator)
		{
			return text.Split(seperator).Shift().Join(seperator);
		}
		
		#endregion
		
		#region UnShift

		public static T[] UnShift<T>(this T[] array, T firstElement)
		{
			T[] newArray = new T[array.LongLength + 1];
			
			newArray[0] = firstElement;
			
			for (long i = 0; i < array.LongLength; i++) {
				newArray[i + 1] = array[i];
			}
			
			return newArray;
		}
		
		public static string UnShift(this string text, string firstElement)
		{
			return text.UnShift(firstElement, ' ');
		}
		
		public static string UnShift(this string text, string firstElement, char seperator)
		{
			return text.Split(seperator).UnShift(firstElement).Join(seperator);
		}
		
		public static string UnShift(this string text, string firstElement, string seperator)
		{
			return text.Split(seperator).UnShift(firstElement).Join(seperator);
		}

		#endregion
		
		#region Pop
		
		public static T[] Pop<T>(this T[] array)
		{
			if (array.LongLength <= 1) {
				return new T[] { };	
			}
			
			long length = array.LongLength - 1;
			
			T[] newArray = new T[length];
			
			for (long i = 0; i < length; i++) {
				newArray[i] = array[i];
			}
			
			return newArray;
		}
		
		public static string Pop(this string text)
		{
			return text.Pop(' ');
		}
		
		public static string Pop(this string text, char seperator)
		{
			return text.Split(seperator).Pop().Join(seperator);
		}
		
		public static string Pop(this string text, string seperator)
		{
			return text.Split(seperator).Pop().Join(seperator);
		}
		
		#endregion
		
		#region Push
		
		public static T[] Push<T>(this T[] array, T lastElement)
		{
			T[] newArray = new T[array.LongLength + 1];
			
			for (long i = 0; i < array.LongLength; i++) {
				newArray[i] = array[i];	
			}
			
			newArray[array.LongLength] = lastElement;
			
			return newArray;
		}
		
		public static string Push(this string text, string lastElement)
		{
			return text.Push(lastElement, ' ');
		}
		
		public static string Push(this string text, string lastElement, char seperator)
		{
			return text.Split(seperator).Push(lastElement).Join(seperator);
		}
		
		public static string Push(this string text, string lastElement, string seperator)
		{
			return text.Split(seperator).Push(lastElement).Join(seperator);
		}
		
		#endregion
		
		#region Compact
		
		public static T[] Compact<T>(T[] array)
		{
			List<T> list = new List<T>();
			
			foreach (var element in array) {
				if (element != null) {	
					list.Add(element);	
				}
			}
			
			return list.ToArray();
		}
		
		#endregion
		
		#region Unique
		
		public static T[] Unique<T>(T[] array)
		{
			List<T> list = new List<T>();
			
			foreach (var element in array) {
				if (!list.Contains(element)) {
					list.Add(element);
				}
			}
			return list.ToArray();
		}
		
		#endregion
		
	}
}

