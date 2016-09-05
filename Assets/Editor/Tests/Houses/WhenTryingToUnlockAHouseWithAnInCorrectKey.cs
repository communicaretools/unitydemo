using System;
using NUnit.Framework;
using Neighbourhood.Game.Outdoors.Houses;

namespace Neighbourhood.Editor.Tests.Houses
{

	[TestFixture]
	public class WhenTryingToUnlockAHouseWithAnInCorrectKey
	{
		House house;
		bool result;

		[SetUp]
		public void Given()
		{
			house = new House(new HouseData { RequiredKeyCode = "KEY_GREEN" });
			result = house.AttemptToUnlock(new Key { Code = "KEY_YELLOW" });
		}

		[Test]
		public void TheUnlockMethodReturnsFalse()
		{
			Assert.That(result, Is.False);
		}

		[Test]
		public void TheHouseHasTheLockedStatus()
		{
			Assert.That(house.IsUnlocked, Is.False);
		}
	}
}
