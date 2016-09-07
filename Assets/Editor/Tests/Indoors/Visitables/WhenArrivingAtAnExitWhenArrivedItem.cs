using NUnit.Framework;
using Neighbourhood.Game.Indoors.Visitables;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;
using Neighbourhood.Game.Places;
using Neighbourhood.Editor.Tests.TestExtensions;

namespace Neighbourhood.Editor.Tests.Indoors.Visitables
{
	[TestFixture]
	public class WhenArrivingAtAnExitWhenArrivedItem
	{
		bool exited;

		[SetUp]
		public void Given()
		{
			var item = new StubVisitable();
			var arrived = new PlayerArrivedAtDestinationSignal();
			var exit = new ExitHouseCommand();
			exited = false;
			exit.Construct(() => exited = true);

			var controller = new ExitHouseOnArrivalController { PlayerArrived = arrived, Exit = exit };
			controller.Init(new ViewStub { Item = item });
			arrived.SimulateTrigger(item);
		}

		[Test]
		public void TheExitHouseCommandIsInvoked()
		{
			Assert.That(exited, Is.True, "Expected the ExitHouseCommand to have been invoked");
		}

		class ViewStub : IExitHouseView
		{
			public IVisitableItem Item { get; set; }
		}
	}
}

