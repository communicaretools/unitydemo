namespace Neighbourhood.Game.Inventory
{
	public class Item
	{
		public string Name { get; private set; }
		public string Type { get; private set; }
		public object Data { get; private set;}

		public Item (string name, string type, object data)
		{
			Name = name;
			Type = type;
			Data = data;
		}
	}
}
