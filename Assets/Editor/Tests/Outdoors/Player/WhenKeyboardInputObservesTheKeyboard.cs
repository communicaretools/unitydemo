using NUnit.Framework;
using Neighbourhood.Editor.Tests.Stubs;
using Neighbourhood.Game.Outdoors.FirstPersonPlayer;

namespace Neighbourhood.Editor.Tests.Outdoors.Player
{
	[TestFixture]
	public class WhenKeyboardInputObservesTheKeyboard
	{
		InputStub input;

		InputState state;

		KeyboardInput handler;

		[SetUp]
		public void Given()
		{
			input = new InputStub();
			state = new InputState();
			handler = new KeyboardInput(input, state);
		}

		[Test]
		public void PositiveHorizontalInputIsInterpretedAsRotateRight()
		{
			input.Horizontal = 1f;
			handler.Tick();
			Assert.That(state.Rotation, Is.EqualTo(RotationDirection.Right));
			Assert.That(state.Direction, Is.EqualTo(MovementDirection.Still));
		}

		[Test]
		public void NegativeHorizontalInputIsInterpretedAsRotateLeft()
		{
			input.Horizontal = -1f;
			handler.Tick();
			Assert.That(state.Rotation, Is.EqualTo(RotationDirection.Left));
			Assert.That(state.Direction, Is.EqualTo(MovementDirection.Still));
		}

		[Test]
		public void PositiveVerticalInputIsInterpretedAsMoveForward()
		{
			input.Vertical = 1f;
			handler.Tick();
			Assert.That(state.Direction, Is.EqualTo(MovementDirection.Forward));
			Assert.That(state.Rotation, Is.EqualTo(RotationDirection.None));
		}

		[Test]
		public void NegativeVerticalInputIsInterpretedAsMoveBackward()
		{
			input.Vertical = -1f;
			handler.Tick();
			Assert.That(state.Direction, Is.EqualTo(MovementDirection.Backward));
			Assert.That(state.Rotation, Is.EqualTo(RotationDirection.None));
		}

		[Test]
		public void CombinedInputIsInterpretedAsMoveAndRotate()
		{
			input.Horizontal = 1f;
			input.Vertical = 1f;
			handler.Tick();
			Assert.That(state.Direction, Is.EqualTo(MovementDirection.Forward));
			Assert.That(state.Rotation, Is.EqualTo(RotationDirection.Right));
		}
	}
}

