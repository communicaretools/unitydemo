using NUnit.Framework;
using Neighbourhood.Game.Player;

namespace Neighbourhood.Editor.Tests.Player
{
	[TestFixture]
	public class WhenPlayerMoveHandlerObservesTheInputState
	{
		PlayerStub player;
		InputState input;
		PlayerMoveHandler handler;

		[SetUp]
		public void Given()
		{
			player = new PlayerStub();
			input = new InputState();
			var settings = new PlayerSettings.Movement {
				ForwardSpeed = 2f,
				RotationSpeed = 10f
			};
			handler = new PlayerMoveHandler(player, input, settings);
		}

		[Test]
		public void ForwardMovementMovesThePlayerForward()
		{
			input.Direction = MovementDirection.Forward;
			handler.Tick();
			Assert.That(player.Transform.Position, Is.EqualTo(2 * player.Transform.Forward));
		}
	}
}
