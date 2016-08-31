using Zenject;

namespace Neighbourhood.Game.Inventory
{
	public class InventoryInstaller : Installer<InventoryInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<Inventory>().ToSelf().AsSingle();
			Container.BindSignal<InventoryItemAddedSignal>();
			Container.BindTrigger<InventoryItemAddedSignal.Trigger>();
			Container.BindAllInterfaces<ShowMessageOnInventoryItemAdded>().To<ShowMessageOnInventoryItemAdded>().AsSingle();
		}
	}
}

