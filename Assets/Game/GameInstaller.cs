using System;
using Zenject;
using Neighbourhood.Game.UnityIntegration.Implementation;
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
			FirstPersonPlayer.PlayerInstaller.Install(Container, Settings.Player);
			ThirdPersonPlayer.PlayerInstaller.Install(Container);
			InventoryInstaller.Install(Container);
			HouseInstaller.Install(Container);
			FlashMessagesInstaller.Install(Container, Settings.FlashMessages);
			LevelInstaller.Install(Container);
			UnityIntegrationInstaller.Install(Container);
		}

		[Serializable]
		public class GameSettings
		{
			public FirstPersonPlayer.PlayerSettings Player;
			public FlashMessageSettings FlashMessages;
		}
	}
}

