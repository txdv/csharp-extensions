using System;
using NUnit.Framework;
using Extensions;

namespace Extensions.Tests.Array
{
	[TestFixture]
	public class IsInFixture
	{

		[Test]
		public void EmptyArray()
		{
			object[] emptyArray = new object[] { };
			
			Assert.IsFalse((new object().IsIn(emptyArray)));
		}
	}
}

