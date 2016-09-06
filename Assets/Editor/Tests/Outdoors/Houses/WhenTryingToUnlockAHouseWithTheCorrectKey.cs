using System;
using NUnit.Framework;
using Neighbourhood.Game.Outdoors.Houses;

namespace Neighbourhood.Editor.Tests.Outdoors.Houses
{
	[TestFixture]
	public class WhenTryingToUnlockAHouseWithTheCorrectKey
	{
		House house;
		bool result;

		[SetUp]
		public void Given()
		{
			house = new House(new HouseData { RequiredKeyCode = "KEY_GREEN" });
			result = house.AttemptToUnlock(new Key { Code = "KEY_GREEN" });
		}

		[Test]
		public void TheUnlockMethodReturnsTrue()
		{
			Assert.That(result, Is.True);
		}

		[Test]
		public void TheHouseHasTheUnlockedStatus()
		{
			Assert.That(house.IsUnlocked, Is.True);
		}
	}
}

