using System;

namespace Neighbourhood.Game.Houses
{
	public class House
	{
		private string requiredKey;
		public bool IsUnlocked { get; private set; }

		public House(HouseData data)
		{
			this.requiredKey = requiredKey;
		}

		public bool AttemptToUnlock(Key key)
		{
			throw new NotImplementedException();
		}
	}
}

