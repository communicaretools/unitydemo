using NUnit.Framework;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;
using Zenject;
using Neighbourhood.Editor.Tests.Stubs;
using Neighbourhood.Editor.Tests.TestExtensions;
using UnityEngine;

namespace Neighbourhood.Editor.Tests.ThirdPersonPlayer
{

	[TestFixture]
	public class WhenThePlayerArrivesAtDestinationTheMovementController
	{
		PlayerMovementBehaviourStub behaviour;
		bool triggerWasFired;

		[SetUp]
		public void Given()
		{
			var leavingSignal = new PlayerDestinationChangedSignal();
			var playerArrivedTrigger = new PlayerArrivedAtDestinationSignal.Trigger();
			triggerWasFired = false;
			playerArrivedTrigger.SetupSignalListenerForTesting<PlayerArrivedAtDestinationSignal>(() => triggerWasFired = true);
			var controller = new PlayerMovementController(leavingSignal, playerArrivedTrigger);
			((IInitializable)controller).Initialize();

			RunSimulation(leavingSignal, controller);
		}

		void RunSimulation(PlayerDestinationChangedSignal leavingSignal, PlayerMovementController controller)
		{
			behaviour = new PlayerMovementBehaviourStub();
			controller.Init(behaviour);

			behaviour.NavMeshAgent.IsNavigating = false;
			leavingSignal.SimulateTrigger(new PlayerDestinationChangedSignal.Arguments());
			controller.Tick();
			Assert.That(triggerWasFired, Is.False, "Trigger fired too early, on navigation start rather than end");

			behaviour.NavMeshAgent.IsNavigating = true;  // gets set on next frame after assigning position
			controller.Tick();

			behaviour.NavMeshAgent.IsNavigating = false;
			controller.Tick();
		}

		[Test]
		public void FiresThePlayerArrivedTrigger()
		{
			Assert.That(triggerWasFired, "Expected trigger to have been fired");
		}

		[Test]
		public void TransitionsItsAnimationToTheIdleState()
		{
			Assert.That(behaviour.Animator.GetSetting<bool>("Walking"), Is.False);
		}

		class PlayerMovementBehaviourStub : BaseBehaviourStub, IPlayerMovementBehaviour { }
	}
}
