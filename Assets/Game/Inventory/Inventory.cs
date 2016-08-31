using System.Collections.Generic;
using System.Linq;

namespace Neighbourhood.Game.Inventory
{
	public class Inventory
	{
		readonly InventoryItemAddedSignal.Trigger trigger;
		readonly IList<Item> items;
		public IEnumerable<Item> Items { get { return items; } }

		public Inventory(InventoryItemAddedSignal.Trigger trigger)
		{
			this.trigger = trigger;
			items = new List<Item>();
		}

		public void Add(Item item)
		{
			items.Add(item);
			trigger.Fire(item);
		}

		public IEnumerable<T> GetItemDataOfType<T>()
		{
			return items.Where(i => i.Data is T).Select(i => (T)i.Data);
		}
	}

}

