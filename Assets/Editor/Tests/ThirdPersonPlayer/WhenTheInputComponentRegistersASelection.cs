using System;
using NUnit.Framework;
using Neighbourhood.Editor.Tests.Stubs;
using Neighbourhood.Editor.Tests.TestExtensions;
using Neighbourhood.Game.Indoors.ThirdPersonPlayer;
using UnityEngine;

namespace Neighbourhood.Editor.Tests.ThirdPersonPlayer
{
	[TestFixture]
	public class WhenTheInputComponentRegistersASelection
	{
		Vector3 emittedPosition;

		[SetUp]
		public void Given()
		{
			var input = new InputStub();
			var coordinateUtility = new CoordinateUtilityStub { ScreenToWorldTransform = _ => new Vector3(1f, 2f, 3f) };
			var trigger = new PlayerDestinationChangedSignal.Trigger();
			emittedPosition = Vector3.zero;
			trigger.SetupSignalListenerForTesting<PlayerDestinationChangedSignal, Vector3>(pos => emittedPosition = pos);
			var handler = new UpdatePlayerDestinationFromInput(input, coordinateUtility, trigger);
			input.SelectedPoint = new Vector2(42, 42);
			handler.Tick();
		}

		[Test]
		public void TheCorrespondingWorldPositionIsPublishedAsDestinationForThePlayer()
		{
			Assert.That(emittedPosition, Is.EqualTo(new Vector3(1f, 2f, 3f)));
		}
	}
}

