using System;

namespace Neighbourhood.Game.Houses
{
	public class HouseController
	{
		House house;
		readonly HouseRegistry registry;
		readonly Inventory.Inventory inventory;

		public HouseController(HouseRegistry registry, Inventory.Inventory inventory)
		{
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
			throw new NotImplementedException();
		}
	}

}

