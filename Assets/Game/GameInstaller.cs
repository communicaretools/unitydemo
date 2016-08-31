using System;
using Zenject;
using Neighbourhood.Game.Player;
using Neighbourhood.Game.UnityIntegration;
using Neighbourhood.Game.Inventory;
using Neighbourhood.Game.FlashMessages;
using Neighbourhood.Game.Levels;
using Neighbourhood.Game.Houses;

namespace Neighbourhood.Game
{
	public class GameInstaller : MonoInstaller
	{
		public GameSettings Settings;

		public override void InstallBindings()
		{
			PlayerInstaller.Install(Container, Settings.Player);
			InventoryInstaller.Install(Container);
			HouseInstaller.Install(Container);
			FlashMessagesInstaller.Install(Container, Settings.FlashMessages);
			LevelInstaller.Install(Container);
			UnityIntegrationInstaller.Install(Container);
		}

		[Serializable]
		public class GameSettings
		{
			public PlayerSettings Player;
			public FlashMessageSettings FlashMessages;
		}
	}
}

