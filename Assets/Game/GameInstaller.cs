using System;
using Zenject;
using Neighbourhood.Game.Player;
using Neighbourhood.Game.UnityIntegration;
using Neighbourhood.Game.Inventory;

namespace Neighbourhood.Game
{
	public class GameInstaller : MonoInstaller
	{
		public GameSettings Settings;

		public override void InstallBindings()
		{
			PlayerInstaller.Install(Container, Settings.Player);
			InventoryInstaller.Install(Container);
			UnityIntegrationInstaller.Install(Container);
		}

		[Serializable]
		public class GameSettings
		{
			public PlayerSettings Player;
		}
	}
}

