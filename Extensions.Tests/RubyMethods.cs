using System;
using NUnit.Framework;
using Extensions;

namespace Extensions.Tests
{
	[TestFixture]
	public class ObjectArray
	{
		[Test]
		public void Join()
		{
			object[] emptyObjectArray = new object[] { };
			
			Assert.IsEmpty(emptyObjectArray.Join());
			Assert.IsEmpty(emptyObjectArray.Join(""));
			Assert.IsEmpty(emptyObjectArray.Join(' '));
			Assert.IsEmpty(emptyObjectArray.Join(" "));
			
			string[] helloWorldArray = new string[] { "hello", "world" };
			Assert.AreEqual(helloWorldArray.Join() , "helloworld");
			Assert.AreEqual(helloWorldArray.Join(' '), "hello world");
			Assert.AreEqual(helloWorldArray.Join(" "), "hello world");
		}
		
		[Test]
		public void Shift()
		{
			object[] emptyObjectArray = new object[] { };
			
			Assert.IsEmpty(emptyObjectArray.Shift());
			
		}
	}
}

