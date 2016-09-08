using NUnit.Framework;
using Neighbourhood.Game.Outdoors.FirstPersonPlayer;
using UnityEngine;

namespace Neighbourhood.Editor.Tests.Outdoors.Player
{
	[TestFixture]
	public class WhenPlayerMoveHandlerObservesTheInputState
	{
		PlayerStub player;
		InputState input;
		MovePlayerController handler;

		[SetUp]
		public void Given()
		{
			player = new PlayerStub();
			input = new InputState();
			var settings = new PlayerSettings.Movement {
				ForwardSpeed = 2f,
				RotationSpeed = 10f
			};
			handler = new MovePlayerController(player, input, settings);
		}

		[Test]
		public void AtRestNothingHappens()
		{
			input.Direction = MovementDirection.Still;
			input.Rotation = RotationDirection.None;
			handler.Tick();
			Assert.That(player.Transform.Position, Is.EqualTo(new Vector3()));
			Assert.That(player.Transform.Rotation, Is.EqualTo(new Vector3()));
		}

		[Test]
		public void ForwardMovementMovesThePlayerForward()
		{
			input.Direction = MovementDirection.Forward;
			handler.Tick();
			Assert.That(player.Transform.Position, Is.EqualTo(2 * player.Transform.Forward));
		}

		[Test]
		public void BackwardsMovementMovesThePlayerBackwards()
		{
			input.Direction = MovementDirection.Backward;
			handler.Tick();
			Assert.That(player.Transform.Position, Is.EqualTo(2 * -player.Transform.Forward));
		}

		[Test]
		public void RightRotationRotatesPlayerTowardsTheRight()
		{
			input.Rotation = RotationDirection.Right;
			handler.Tick();
			Assert.That(player.Transform.Rotation.y, Is.EqualTo(10f));
		}

		[Test]
		public void LeftRotationRotatesPlayerTowardsTheLeft()
		{
			input.Rotation = RotationDirection.Left;
			handler.Tick();
			Assert.That(player.Transform.Rotation.y, Is.EqualTo(-10f));
		}
	}
}
