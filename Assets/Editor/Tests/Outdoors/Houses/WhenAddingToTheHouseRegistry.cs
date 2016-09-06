using NUnit.Framework;
using Neighbourhood.Game.Outdoors.Houses;
using System.Linq;

namespace Neighbourhood.Editor.Tests.Outdoors.Houses
{
	[TestFixture]
	public class WhenAddingToTheHouseRegistry
	{
		HouseRegistry registry;

		[SetUp]
		public void Given()
		{
			registry = new HouseRegistry();
			registry.AddHouse(new House(new HouseData { RequiredKeyCode = "KEY_BLUE" }));
		}

		[Test]
		public void AHouseIsAdded()
		{
			Assert.That(registry.Houses.Count(), Is.EqualTo(1));
		}
	}
}

