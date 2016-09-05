using System;
using Neighbourhood.Game.FlashMessages;
using Neighbourhood.Game.Levels;

namespace Neighbourhood.Game.Outdoors.Houses
{
	public class HouseController
	{
		House house;
		readonly HouseRegistry registry;
		readonly Inventory.Inventory inventory;
		readonly ShowMessageCommand showMessage;
		readonly EnterHouseCommand loadLevel;

		public HouseController(HouseRegistry registry, Inventory.Inventory inventory, ShowMessageCommand showMessage, EnterHouseCommand loadLevel)
		{
			this.loadLevel = loadLevel;
			this.showMessage = showMessage;
			this.inventory = inventory;
			this.registry = registry;
		}

		public void Initialize(HouseData data)
		{
			house = new House(data);
			registry.AddHouse(house);
		}

		public void PlayerArrived()
		{
			var couldUnlock = TryToUnlock();
			if (!couldUnlock)
			{
				showMessage.Execute("You don't have the correct key to unlock this house");
				return;
			}
			loadLevel.Execute(house.LevelToLoad);
		}

		bool TryToUnlock()
		{
			foreach (var key in inventory.GetItemDataOfType<Key>())
			{
				if (house.AttemptToUnlock(key))
				{
					return true;
				}
			}

			return false;
		}
	}

}

