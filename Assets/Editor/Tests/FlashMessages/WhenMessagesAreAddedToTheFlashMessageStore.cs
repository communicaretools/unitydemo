using System;
using NUnit.Framework;
using Neighbourhood.Game.FlashMessages;

namespace Neighbourhood.Editor.Tests.FlashMessages
{
	[TestFixture]
	public class WhenMessagesAreAddedToTheFlashMessageStore
	{
		FlashMessageStore store;

		[SetUp]
		public void Given()
		{
			store = new FlashMessageStore(new FlashMessageSettings {TimeoutInSeconds = 5f});
			store.HandleShowMessage("test");
		}

		[Test]
		public void ItIsReturnedAsTheLastMessageRegardlessOfTime()
		{
			Assert.That(store.GetLatestMessage(42f), Is.EqualTo("test"));
		}

		[Test]
		public void ItDisappearsAfterTheTimeoutGivenInSettings()
		{
			Assert.That(store.GetLatestMessage(21f), Is.EqualTo("test"));
			Assert.That(store.GetLatestMessage(42f), Is.Null);
		}
	}
}

