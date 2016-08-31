using System;
using NUnit.Framework;
using Neighbourhood.Game.Inventory;
using Neighbourhood.Game.FlashMessages;
using Neighbourhood.Editor.Tests.TestExtensions;

namespace Neighbourhood.Editor.Tests.Inventory
{
	[TestFixture]
	public class WhenInventoryItemAddedIsTriggered
	{
		string scheduledMessage;

		[SetUp]
		public void Given()
		{
			var signal = new InventoryItemAddedSignal();
			var command = new ShowMessageCommand();
			scheduledMessage = null;
			command.Construct(msg => scheduledMessage = msg);

			var handler = new ShowMessageOnInventoryItemAdded(signal, command);
			handler.Initialize();
			signal.SimulateTrigger(new Item("Test item", new {}));
			handler.Dispose();
		}

		[Test]
		public void AMessageIsDispatched()
		{
			Assert.That(scheduledMessage, Contains.Substring("Test item"));
		}
	}
}

