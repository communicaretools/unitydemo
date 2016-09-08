using System;
using Zenject;
using Neighbourhood.Game.UnityIntegration.Implementation;
using Neighbourhood.Game.Inventory;
using Neighbourhood.Game.FlashMessages;
using Neighbourhood.Game.Places;

namespace Neighbourhood.Game
{
	public class GameInstaller : MonoInstaller
	{
		public GameSettings Settings;

		public override void InstallBindings()
		{
			InventoryInstaller.Install(Container, Settings.Inventory);
			FlashMessagesInstaller.Install(Container, Settings.FlashMessages);
			PlacesInstaller.Install(Container);
			UnityIntegrationInstaller.Install(Container);
		}

		[Serializable]
		public class GameSettings
		{
			public FlashMessageSettings FlashMessages;
			public InventoryInstaller.InventorySettings Inventory;
		}
	}
}
