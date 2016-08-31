using System;
using UnityEngine;

namespace Neighbourhood.Game.FlashMessages
{
	public class ShowMessageHandler
	{
		public void Handle(string message)
		{
			Debug.Log("Message: " + message);
		}
	}
}

