using System;

namespace Neighbourhood.Game.Houses
{
	public class House
	{
		readonly string requiredKey;
		public bool IsUnlocked { get; private set; }

		public House(HouseData data)
		{
			this.requiredKey = data.RequiredKeyCode;
		}

		public bool AttemptToUnlock(Key key)
		{
			if (key.Code != requiredKey)
			{
				return false;
			}

			IsUnlocked = true;
			return true;
		}
	}
}

