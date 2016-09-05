using NUnit.Framework;
using Neighbourhood.Game.Outdoors.Houses;
using Neighbourhood.Game.FlashMessages;
using Neighbourhood.Game.Levels;

namespace Neighbourhood.Editor.Tests.Houses
{
	[TestFixture]
	public class WhenThePlayerArrivesAtAHouseWithoutTheCorrectKey
	{
		string dispatchedMessage;

		[SetUp]
		public void Given()
		{
			var registry = new HouseRegistry();
			var inventory = new Game.Inventory.Inventory(new Neighbourhood.Game.Inventory.InventoryItemAddedSignal.Trigger());

			var showMessageCommand = new ShowMessageCommand();
			dispatchedMessage = null;
			showMessageCommand.Construct(msg => dispatchedMessage = msg);
			var loadLevelCommand = new LoadLevelCommand();
			loadLevelCommand.Construct(levelName => Assert.Fail("Not supposed to load a level if the player doesn't have the correct key"));

			var controller = new HouseController(registry, inventory, showMessageCommand, loadLevelCommand);
			controller.Initialize(new HouseData { RequiredKeyCode = "KEY_GREEN" });
			controller.PlayerArrived();
		}

		[Test]
		public void AMessageToTheUserIsDispatched()
		{
			Assert.That(string.IsNullOrEmpty(dispatchedMessage), Is.False);
		}
	}


}

