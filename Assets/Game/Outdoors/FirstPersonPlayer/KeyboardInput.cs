using Zenject;
using Neighbourhood.Game.UnityIntegration.Abstractions;

namespace Neighbourhood.Game.Outdoors.FirstPersonPlayer
{
	public class KeyboardInput : ITickable
	{
		readonly IInput input;
		readonly InputState state;

		public KeyboardInput (IInput input, InputState state)
		{
			this.input = input;
			this.state = state;
		}

		#region ITickable implementation

		public void Tick()
		{
			if (state.Source != InputSource.Input)
			{
				return;
			}

			if (input.GetHorizontal() > 0f)
			{
				state.Rotation = RotationDirection.Right;
			}
			else if (input.GetHorizontal() < 0f)
			{
				state.Rotation = RotationDirection.Left;
			}
			else
			{
				state.Rotation = RotationDirection.None;
			}
			if (input.GetVertical() > 0f)
			{
				state.Direction = MovementDirection.Forward;
			}
			else if (input.GetVertical() < 0f)
			{
				state.Direction = MovementDirection.Backward;
			}
			else
			{
				state.Direction = MovementDirection.Still;
			}
		}

		#endregion
	}
}

