using Zenject;
using UnityEngine;

namespace Neighbourhood.Game.Player
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
			player.Transform.Position += player.Transform.Forward * settings.ForwardSpeed;
		}

		#endregion
	}
}

