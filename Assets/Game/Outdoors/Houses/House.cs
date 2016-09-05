using System;

namespace Neighbourhood.Game.Outdoors.Houses
{
	public class House
	{
		readonly string requiredKey;
		public bool IsUnlocked { get; private set; }
		public string LevelToLoad { get; private set; }

		public House(HouseData data)
		{
			this.requiredKey = data.RequiredKeyCode;
			LevelToLoad = data.LoadLevel;
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

