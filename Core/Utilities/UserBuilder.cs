using System;
using NUnit.Framework;

namespace Core.Utilities
{
	public static class UserBuilder
	{
		public static User StandartUser => new User
		{
			Name = TestContext.Parameters.Get("UserName"),
			Password = TestContext.Parameters.Get("UserPassword"),
		};
	}
}

