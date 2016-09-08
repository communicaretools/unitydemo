using Zenject;

namespace Neighbourhood.Game.Outdoors.FirstPersonPlayer
{
	public class MovePlayerController
	{
		readonly InputState state;
		readonly PlayerSettings.Movement settings;
		IMovePlayerView player;

		[Inject]
		public MovePlayerController(InputState state, PlayerSettings.Movement settings)
		{
			this.settings = settings;
			this.state = state;
		}

		public void Init(IMovePlayerView player)
		{
			this.player = player;
		}

		public void Update(float deltaTime)
		{
			if (player == null) { return; }
			if (state.Direction == MovementDirection.Forward)
			{
				player.Transform.Position += player.Transform.Forward * settings.ForwardSpeed * deltaTime;
			}
			else if (state.Direction == MovementDirection.Backward)
			{
				player.Transform.Position -= player.Transform.Forward * settings.ForwardSpeed * deltaTime;
			}
			if (state.Rotation == RotationDirection.Right)
			{
				player.Transform.Rotate(0f, settings.RotationSpeed * deltaTime, 0f);
			}
			else if (state.Rotation == RotationDirection.Left)
			{
				player.Transform.Rotate(0f, -settings.RotationSpeed * deltaTime, 0f);
			}
		}
	}
}

