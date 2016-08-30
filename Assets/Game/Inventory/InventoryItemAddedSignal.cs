using Zenject;

namespace Neighbourhood.Game.Inventory
{
	public class InventoryItemAddedSignal : Signal<Item>
	{
		public class Trigger : TriggerBase {}
	}
}
