using NUnit.Framework;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;
using Neighbourhood.Game.Indoors.Visitables;
using Neighbourhood.Editor.Tests.TestExtensions;

namespace Neighbourhood.Editor.Tests.Indoors.Visitables
{
	[TestFixture]
	public class WhenArrivingAtAnItemThatGlowsWhenApproached
	{
		StubGlowingView view;

		[SetUp]
		public void Given()
		{
			var item = new StubVisitable();
			var approaching = new PlayerDestinationChangedSignal();
			var arrived = new PlayerArrivedAtDestinationSignal();
			var controller = new GlowWhenApproachedController { DestinationChanged = approaching, DestinationReached = arrived };
			view = new StubGlowingView(item);
			controller.InitView(view);

			approaching.SimulateTrigger(new PlayerDestinationChangedSignal.Arguments {Destination = item});
			arrived.SimulateTrigger(new StubVisitable());
		}

		[Test]
		public void TheItemStopsGlowing()
		{
			Assert.That(view.IsGlowing, Is.False);
			Assert.That(view.StoppedToGlow);
		}
	}
}

