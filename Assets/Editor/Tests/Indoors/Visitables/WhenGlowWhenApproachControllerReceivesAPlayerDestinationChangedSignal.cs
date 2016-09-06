using NUnit.Framework;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;
using Neighbourhood.Game.Indoors.Visitables;
using Neighbourhood.Editor.Tests.TestExtensions;

namespace Neighbourhood.Editor.Tests.Indoors.Visitables
{
	[TestFixture]
	public class WhenGlowWhenApproachControllerReceivesAPlayerDestinationChangedSignal
	{
		StubVisitable item;
		PlayerDestinationChangedSignal approaching;
		StubGlowingView view;

		[SetUp]
		public void Given()
		{
			item = new StubVisitable();
			approaching = new PlayerDestinationChangedSignal();
			var controller = new GlowWhenApproachedController { DestinationChanged = approaching, DestinationReached = new PlayerArrivedAtDestinationSignal() };
			view = new StubGlowingView(item);
			controller.InitView(view);
		}

		[Test]
		public void ItGlowsIfTheSignalConcernsTheViewAttachedToTheController()
		{
			approaching.SimulateTrigger(new PlayerDestinationChangedSignal.Arguments {Destination = item});
			Assert.That(view.IsGlowing, Is.True);
		}

		[Test]
		public void ItDoesntGlowIfTheSignalConcernsAnotherView()
		{
			approaching.SimulateTrigger(new PlayerDestinationChangedSignal.Arguments {Destination = new StubVisitable()});
			Assert.That(view.IsGlowing, Is.False);
		}

		[Test]
		public void ItStopsToGlowIfGettingASignalForAnotherViewWhileGlowing()
		{
			approaching.SimulateTrigger(new PlayerDestinationChangedSignal.Arguments {Destination = item});
			Assert.That(view.IsGlowing, Is.True);
			approaching.SimulateTrigger(new PlayerDestinationChangedSignal.Arguments {Destination = new StubVisitable()});
			Assert.That(view.IsGlowing, Is.False);
		}
	}
}

