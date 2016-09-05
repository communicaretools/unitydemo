using System;

namespace Neighbourhood.Game.Outdoors.FirstPersonPlayer
{
	[Serializable]
	public class PlayerSettings
	{
		public PlayerBehaviour Player;
		public Movement MovementSettings;

		public PlayerSettings ()
		{
			// set up sensible defaults here; they can be tweaked in the editor
			MovementSettings = new Movement { ForwardSpeed = 1.5f, RotationSpeed = 15f };
		}

		[Serializable]
		public class Movement
		{
			public float ForwardSpeed;
			public float RotationSpeed;
		}
	}
}

