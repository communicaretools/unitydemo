using System;

namespace Neighbourhood.Game.Outdoors.FirstPersonPlayer
{
	public enum MovementDirection
	{
		Still,
		Forward,
		Backward
	}

	public enum RotationDirection
	{
		None,
		Left,
		Right
	}

	public enum InputSource
	{
		Input,
		Touch
	}

	public class InputState
	{
		public InputSource Source { get; set; }
		public MovementDirection Direction { get; set; }
		public RotationDirection Rotation { get; set; }
	}
}

