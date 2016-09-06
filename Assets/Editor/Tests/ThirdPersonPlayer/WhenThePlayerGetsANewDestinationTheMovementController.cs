using NUnit.Framework;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;
using Zenject;
using Neighbourhood.Editor.Tests.Stubs;
using Neighbourhood.Editor.Tests.TestExtensions;
using UnityEngine;

namespace Neighbourhood.Editor.Tests.ThirdPersonPlayer
{
	[TestFixture]
	public class WhenThePlayerGetsANewDestinationTheMovementController
	{
		PlayerMovementBehaviourStub behaviour;

		[SetUp]
		public void Given()
		{
			var leavingSignal = new PlayerDestinationChangedSignal();
			var arrivalTrigger = new PlayerArrivedAtDestinationSignal.Trigger();
			var controller = new PlayerMovementController(leavingSignal, arrivalTrigger);
			((IInitializable)controller).Initialize();

			behaviour = new PlayerMovementBehaviourStub();
			controller.Init(behaviour);
			leavingSignal.SimulateTrigger(new PlayerDestinationChangedSignal.Arguments {Coordinate = new Vector3(1f, 2f, 3f)});
		}

		[Test]
		public void SetsTheDestinationOfItsNavigationAgent()
		{
			Assert.That(behaviour.NavMeshAgent.Destination, Is.EqualTo(new Vector3(1f, 2f, 3f)));
		}

		[Test]
		public void TransitionsItsAnimationToTheWalkingState()
		{
			Assert.That(behaviour.Animator.GetSetting<bool>("Walking"), Is.True);
		}

		class PlayerMovementBehaviourStub : BaseBehaviourStub, IPlayerMovementBehaviour { }
	}

}

