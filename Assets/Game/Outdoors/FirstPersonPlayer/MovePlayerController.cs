using Zenject;

namespace Neighbourhood.Game.Outdoors.FirstPersonPlayer
{
	public class MovePlayerController : ITickable
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

		#region ITickable implementation

		public void Tick()
		{
			if (player == null) { return; }
			if (state.Direction == MovementDirection.Forward)
			{
				player.Transform.Position += player.Transform.Forward * settings.ForwardSpeed;
			}
			else if (state.Direction == MovementDirection.Backward)
			{
				player.Transform.Position -= player.Transform.Forward * settings.ForwardSpeed;
			}
			if (state.Rotation == RotationDirection.Right)
			{
				player.Transform.Rotate(0f, settings.RotationSpeed, 0f);
			}
			else if (state.Rotation == RotationDirection.Left)
			{
				player.Transform.Rotate(0f, -settings.RotationSpeed, 0f);
			}
		}

		#endregion
	}
}

