using System.Linq;
using NUnit.Framework;
using Neighbourhood.Game.Inventory;
using Neighbourhood.Editor.Tests.TestExtensions;

namespace Neighbourhood.Editor.Tests.Inventory
{
	[TestFixture]
	public class WhenAddingItemsToTheInventory
	{
		Game.Inventory.Inventory inventory;
		Item signalledItem;

		[SetUp]
		public void Given()
		{
			signalledItem = null;
			var trigger = new InventoryItemAddedSignal.Trigger();
			trigger.SetupSignalListenerForTesting<InventoryItemAddedSignal, Item>(item => signalledItem = item);
			inventory = new Game.Inventory.Inventory(trigger);
			inventory.Add(new Item("test", new TestData {Code = 42}));
		}

		[Test]
		public void TheItemShowsUpInTheInventory()
		{
			Assert.That(inventory.Items.Select(x => x.Name).ToArray(), Is.EquivalentTo(new[]{"test"}));
		}

		[Test]
		public void ASignalIsEmitted()
		{
			Assert.That(signalledItem, Is.Not.Null);
			Assert.That(signalledItem.Name, Is.EqualTo("test"));
		}

		[Test]
		public void TheDataAddedCanBeRetrievedByType()
		{
			Assert.That(inventory.GetItemDataOfType<TestData>().Single().Code, Is.EqualTo(42));
		}

		class TestData
		{
			public int Code { get; set; }
		}
	}
}

