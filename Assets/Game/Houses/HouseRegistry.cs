using System;
using System.Collections.Generic;

namespace Neighbourhood.Game.Houses
{
	public class HouseRegistry
	{
		readonly IList<House> houses = new List<House>();
		public IEnumerable<House> Houses { get { return houses; } }

		public void AddHouse()
		{
			throw new NotImplementedException();
		}
	}
}

