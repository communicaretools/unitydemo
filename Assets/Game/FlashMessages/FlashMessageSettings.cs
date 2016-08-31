using System;

namespace Neighbourhood.Game.FlashMessages
{
	[Serializable]
	public class FlashMessageSettings
	{
		public float TimeoutInSeconds;

		public FlashMessageSettings ()
		{
			TimeoutInSeconds = 5f;
		}
	}
}

