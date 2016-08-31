namespace Neighbourhood.Game.Inventory
{
	public class Item
	{
		public string Name { get; private set; }
		public object Data { get; private set;}

		public Item (string name, object data)
		{
			Name = name;
			Data = data;
		}
	}
}
