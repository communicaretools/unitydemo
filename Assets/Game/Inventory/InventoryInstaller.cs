using Zenject;
using System;

namespace Neighbourhood.Game.Inventory
{
	public class InventoryInstaller : Installer<InventoryInstaller.InventorySettings, InventoryInstaller>
	{
		InventorySettings settings;

		public InventoryInstaller(InventorySettings settings)
		{
			this.settings = settings;
		}

		public override void InstallBindings()
		{
			Container.BindSignal<InventoryItemAddedSignal>();
			Container.BindTrigger<InventoryItemAddedSignal.Trigger>();

			Container.BindInstance(settings.RendererPositioning);
			Container.Bind<Inventory>().ToSelf().AsSingle();
			Container.BindAllInterfaces<ShowMessageOnInventoryItemAdded>().To<ShowMessageOnInventoryItemAdded>().AsSingle();
			Container.Bind<InventoryRenderer>().ToSelf().FromGameObject().AsSingle().NonLazy();
		}

		[Serializable]
		public class InventorySettings
		{
			public InventoryRenderer.Settings RendererPositioning;
		}
	}
}

