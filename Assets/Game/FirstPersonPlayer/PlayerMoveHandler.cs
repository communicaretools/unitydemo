using Zenject;

namespace Neighbourhood.Game.FirstPersonPlayer
{
	public class PlayerMoveHandler : ITickable
	{
		readonly InputState state;
		readonly PlayerSettings.Movement settings;
		readonly IPlayer player;

		[Inject]
		public PlayerMoveHandler(IPlayer player, InputState state, PlayerSettings.Movement settings)
		{
			this.player = player;
			this.settings = settings;
			this.state = state;
		}

		#region ITickable implementation

		public void Tick()
		{
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

